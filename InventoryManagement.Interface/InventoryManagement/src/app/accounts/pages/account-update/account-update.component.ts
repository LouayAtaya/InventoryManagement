import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountsService ,AccountDetails, AccountTypeMap} from 'src/app/core';
import { NotEmpty } from 'src/app/shared/validators/not-empty.validator';
import { AccountForUpdate } from '../../../core/models/account-for-update';

@Component({
  selector: 'app-account-update',
  templateUrl: './account-update.component.html',
  styleUrls: ['./account-update.component.css']
})
export class AccountUpdateComponent implements OnInit {

  accountId:number;
  accountDetails:AccountDetails;
  defaultAccountTypes:Map<Number,String>;

  accountForm: FormGroup;
  accountForUpdate:AccountForUpdate;

  constructor(private formBuilder: FormBuilder, private accountsService: AccountsService,private route:ActivatedRoute,private router: Router) { 
    this.defaultAccountTypes=AccountTypeMap;

    this.accountForm=formBuilder.group({
      id:[],
      accountCode:['',[Validators.required, Validators.minLength(3), Validators.maxLength(10), NotEmpty]],
      accountType:[null,[Validators.required]],
      amount:[0,[Validators.required]],
      name: ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50), NotEmpty]],
      description:['',[Validators.maxLength(500)]],
      isActive:[true]
    })
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      params=>{
        this.accountId=Number.parseInt(params.get("id"));
        this.initializeFormWithAccount(this.accountId);
      },
      error=>{

      }
    )
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

  initializeFormWithAccount(id:number){
    this.accountsService.GetAccountDetails(id).subscribe(
      data=>{
        this.accountDetails=data;

        this.accountForm.patchValue({
          id:this.accountDetails.id,
          accountCode:this.accountDetails.accountCode,
          accountType:this.accountDetails.accountType,
          amount:this.accountDetails.amount,
          name:this.accountDetails.name,
          description:this.accountDetails.description?this.accountDetails.description:'',
          isActive:this.accountDetails.isActive,
        })

      },
      error=>{

      }
    )
  }


  onSubmit(){
    this.accountForUpdate=new AccountForUpdate(this.accountForm.value);

    this.accountsService.UpdateAccount(this.accountId,this.accountForUpdate)
      .subscribe(
        data=>{
          alert("Updated");
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
