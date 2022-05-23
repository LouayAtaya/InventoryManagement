import { Component, OnInit } from '@angular/core';
import { Account, AccountsService,AccountTypeMap } from '../../core';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css']
})
export class AccountsComponent implements OnInit {

  constructor(private accountsService:AccountsService) { }
  accountTypeMap=AccountTypeMap
  accounts:Account[];

  ngOnInit(): void {
    this.accountsService.GetAccounts().subscribe(
      data=>{
        this.accounts=data;
      },
      error=>{

      }
    )
  }

}
