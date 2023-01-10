import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CreateNamespaceDto, ErrorDto } from '@core/api';

@Component({
  selector: 'app-namespace-form-modal',
  templateUrl: 'namespace-form-modal.component.html'
})
export class NamespaceFormModalComponent implements OnInit {
  @Input() public saving: boolean = false;
  @Input() public error: ErrorDto | undefined;
  @Output() public save = new EventEmitter<CreateNamespaceDto>();
  @Output() public close = new EventEmitter<any>();

  public namespaceForm!: FormGroup;
  public get canSave(): boolean {
    return !this.saving && this.namespaceForm?.valid;
  }

  constructor(private readonly formBuilder: FormBuilder) {
  }

  public ngOnInit(): void {
    this.namespaceForm = this.createNamespaceForm();
  }

  public closeModal(): void {
    this.close.emit();
  }

  public beginSave(): void {
    this.save.emit(this.namespaceForm.value);
  }

  private createNamespaceForm(): FormGroup {
    return this.formBuilder.group({
      name: [null, [Validators.required, Validators.max(50)]],
      description: [null, [Validators.max(200)]]
    })
  }
}
