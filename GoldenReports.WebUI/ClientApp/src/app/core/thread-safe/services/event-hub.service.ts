import { EventEmitter, Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { GlobalEvent } from '@core/thread-safe/models/global-event';
import { isPlatformBrowser } from '@angular/common';

@Injectable({ providedIn: 'root' })
export class EventHubService {
  private static readonly eventPrefix = 'event_hub';
  private readonly hubId!: string;

  public readonly eventTriggered = new EventEmitter<GlobalEvent>();

  constructor(@Inject(PLATFORM_ID) private readonly platformId: any) {
    if (!isPlatformBrowser(platformId)) {
      return;
    }

    this.hubId = window.crypto.randomUUID();
    window.addEventListener('storage', (event) => {
      if (event.key?.startsWith(EventHubService.eventPrefix)) {
        const eventName = event.key.split(':')[1];
        this.eventTriggered.next({
          name: eventName,
          args: event.newValue ? JSON.parse(event.newValue) : undefined,
        });
      }
    });
  }

  public triggerEvent(event: GlobalEvent): void {
    this.eventTriggered.next(event);
    this.triggerEventInAnotherTabs(event);
  }

  private triggerEventInAnotherTabs(event: GlobalEvent): void {
    const eventKey = `${EventHubService.eventPrefix}_${this.hubId}:${event.name}`;
    localStorage.setItem(
      eventKey,
      event.args ? JSON.stringify(event.args) : ''
    );
    localStorage.removeItem(eventKey);
  }
}
