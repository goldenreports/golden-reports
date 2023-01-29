import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ErrorDto, NamespaceDto, UpdateNamespaceDto } from '@core/api';

@Component({
  selector: 'app-namespace-form',
  templateUrl: 'namespace-form.component.html'
})
export class NamespaceFormComponent {
  @Input() public error?: ErrorDto;
  @Input() public loading = false;
  @Input() public set namespace(value: NamespaceDto) {
    this.namespaceForm.reset(value);
  }
  @Output() public save = new EventEmitter<UpdateNamespaceDto>();

  public namespaceForm!: FormGroup;
  public get canSave(): boolean {
    return !this.loading && this.namespaceForm && this.namespaceForm.valid && this.namespaceForm.dirty;
  }

  constructor(private readonly formBuilder: FormBuilder) {
    this.namespaceForm = this.createNamespaceForm();
  }

  public saveNamespace(namespace: UpdateNamespaceDto): void {
    this.save.emit(namespace);
  }

  private createNamespaceForm(): FormGroup {
    return this.formBuilder.group({
      name: [null, [Validators.required]],
      description: [null]
    });
  }
}
