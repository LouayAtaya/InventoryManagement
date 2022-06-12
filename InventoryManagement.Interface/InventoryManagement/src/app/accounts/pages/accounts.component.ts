import { Component, OnInit } from '@angular/core';
import { Account, AccountsService,AccountTypeMap } from '../../core';
import { ContentHeaderService } from '../../core/services/content-header.service';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css']
})
export class AccountsComponent implements OnInit {

  constructor(private accountsService:AccountsService, private contentHeaderService: ContentHeaderService) { }
  accountTypeMap=AccountTypeMap
  accounts:Account[];

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("الحسابات");
    
    this.accountsService.GetAccounts().subscribe(
      data=>{
        this.accounts=data;
      },
      error=>{

      }
    )
  }

}
