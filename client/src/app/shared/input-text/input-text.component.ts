import { Component, Input, Self } from '@angular/core';
import { FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-input-text',
  templateUrl: './input-text.component.html',
  styleUrls: ['./input-text.component.scss']
})
export class InputTextComponent {
  @Input() type = 'text';
  @Input() label = '';

  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;
  }
  writeValue(obj: any): void {
    
  }
  registerOnChange(fn: any): void {
  
  }
  registerOnTouched(fn: any): void {
   
  }

  get control(): FormControl{
    return this.controlDir.control as FormControl
  }
}
