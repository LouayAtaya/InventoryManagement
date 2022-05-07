import { Directive, OnInit } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';

@Directive({
  selector: '[AppNotEmptyValidator]',
  providers: [
    { provide: NG_VALIDATORS, useExisting: NotEmptyValidatorDirective, multi: true }
  ]
})
export class NotEmptyValidatorDirective implements Validator, OnInit   {
  

  
  ngOnInit() {
  }
  
  validate(control: AbstractControl): ValidationErrors {
    let value = control.value as string;
    
    if (value != null && value.trim().length==0) {
      return { 'NotEmpty': true }
    }
 
    return null;  
  }
 

}
