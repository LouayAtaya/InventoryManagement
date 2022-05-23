import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NotEmpty } from 'src/app/shared/validators/not-empty.validator';
import { AccountsService,AccountTypeMap,AccountForCreation } from '../../../core';

@Component({
  selector: 'app-account-create',
  templateUrl: './account-create.component.html',
  styleUrls: ['./account-create.component.css']
})
export class AccountCreateComponent implements OnInit {
  accountForm: FormGroup;
  accountForCreation:AccountForCreation
  defaultAccountTypes:Map<Number,String>;
  
  constructor(private formBuilder: FormBuilder, private accountsService: AccountsService) {
    this.defaultAccountTypes=AccountTypeMap;

    this.accountForm=formBuilder.group({
      accountCode:['',[Validators.required, Validators.minLength(3), Validators.maxLength(10), NotEmpty]],
      accountType:[null,[Validators.required]],
      amount:[0,[Validators.required]],
      name: ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50), NotEmpty]],
      description:['',[Validators.maxLength(500)]],
      isActive:[true]
    })

    
   }

  ngOnInit(): void {
    
  }

  get accountCode(){
    return this.accountForm.get('accountCode');
  }

  get accountType(){
    return this.accountForm.get('accountType');
  }

  get amount(){
    return this.accountForm.get('amount');
  }

  get name(){
    return this.accountForm.get('name');
  }

  get description(){
    return this.accountForm.get('description');
  }

  get accountTypesKeys(){
    return Array.from(this.defaultAccountTypes.keys());
  }


  
  onSubmit(){
    this.accountForCreation=new AccountForCreation(this.accountForm.value);

    this.accountsService.AddAccount(this.accountForCreation)
      .subscribe(
        data=>{
          alert("created");
        },
        error=>{
          console.log("error")
          console.log(error)
          console.log("error")
          alert(error);
        }

      )
  }

}
