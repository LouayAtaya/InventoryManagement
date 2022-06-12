import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountsService, Warehouse, WarehousesService,Account, Item, SaleOrdersService, SaleOrderForCreation, ContentHeaderService } from '../../../core';
import { ItemsService } from '../../../core/services/items.service';

@Component({
  selector: 'app-sale-order-create',
  templateUrl: './sale-order-create.component.html',
  styleUrls: ['./sale-order-create.component.css']
})
export class SaleOrderCreateComponent implements OnInit {
  saleOrderForCreation:SaleOrderForCreation;

  customers: Account[];
  warehouses: Warehouse[];
  items: Item[];
  
  saleOrderForm: FormGroup;
  currentDate= new Date()

  constructor( private formBuilder: FormBuilder,private saleOrdersService: SaleOrdersService, private itemsService: ItemsService,private accountsService: AccountsService, private warehousesService: WarehousesService,private contentHeaderService:ContentHeaderService) { 
    this.saleOrderForm= formBuilder.group({
      customerId:['',[Validators.required]],
      warehouseId: ['',[Validators.required]],
      description:['',[Validators.maxLength(500)]],
      saleOrderItems:this.formBuilder.array([],[Validators.required]),
      totalAmount:[{value: 0, disabled: true},[Validators.required]], 
      isActive:[true],
    })
  }

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("طلب مبيعات جديد")
    
    this.getAllCustomers();
    this.getAllWarehouses();
    this.getAllItems();

    this.saleOrderForm.get("saleOrderItems").valueChanges.subscribe(saleOrderItems => {
      console.log('form value changed')
      console.log(saleOrderItems)
      console.log('form value changed')

      let index=-1;
      let totalAmount=0;
      saleOrderItems.forEach(element => {
        index++;
        console.log(element)
        let selectedItem=this.items.find(i=>i.id==element.itemId);
        console.log(selectedItem)

        //calculate subTotal
        element.subTotal=element.quantity*element.price;

        console.log(element.subTotal)
        this.getSaleOrderItemSubTotal(index).setValue(element.subTotal,{ emitEvent: false })
        totalAmount+=element.subTotal;

        //check Quantity not less than 1
        if(element.quantity<1){
          this.getSaleOrderItemQuantity(index).setErrors({minQuantity:1})

        }


        //check Price not less than selected item price
        if(element.price<selectedItem?.price){
          this.getSaleOrderItemPrice(index).setErrors({minPrice:selectedItem?.price})
        }


      });
      this.saleOrderForm.get("totalAmount").setValue(totalAmount,{ emitEvent: false });

  })
  }

  get saleOrderItems(){
    return this.saleOrderForm.get("saleOrderItems") as FormArray;
  }

  get customerId(){
    return this.saleOrderForm.get('customerId');
  }

  get warehouseId(){
    return this.saleOrderForm.get('warehouseId');
  }

  get description(){
    return this.saleOrderForm.get('description');
  }

  newSaleOrderItem(): FormGroup{
    return this.formBuilder.group({
      itemCode:[{value: null, disabled: true},[Validators.required]],
      itemId:[null,[Validators.required]],
      price:[0,[Validators.required]],
      quantity:[1,[Validators.required]] ,///min value 1
      subTotal:[{value: 0, disabled: true},[Validators.required]] 
    }) 
  }

  addNewSaleOrderItem(){
    this.saleOrderItems.push(this.newSaleOrderItem());
  }

  removeSaleOrderItem(index: number){
    this.saleOrderItems.removeAt(index);
  }

  getSaleOrderItem(index: number){
    return this.saleOrderItems.at(index);
  }
  getSaleOrderItemItemId(index: number){
    return this.saleOrderItems.at(index).get("itemId");
  }

  getSaleOrderItemPrice(index: number){
    return this.saleOrderItems.at(index).get("price");
  }

  getSaleOrderItemQuantity(index: number){
    return this.saleOrderItems.at(index).get("quantity");
  }

  getSaleOrderItemSubTotal(index: number){
    return this.saleOrderItems.at(index).get("subTotal");
  }

  onSubmit(){
    
    this.saleOrderForCreation=new SaleOrderForCreation(this.saleOrderForm.value);
    console.log(this.saleOrderForCreation)

    this.saleOrdersService.addSaleOrder(this.saleOrderForCreation).subscribe(
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

  onNewItemSelected(i){
    console.log("selected")
    console.log(this.getSaleOrderItemItemId(i).value)
    let selectedItemId=this.getSaleOrderItemItemId(i).value
    let selectedItem=this.items.find(i=>i.id==selectedItemId);
    console.log(selectedItem)
    this.getSaleOrderItem(i).patchValue({
      itemCode:selectedItem.code,
      price: selectedItem.price,
      //quantity:[0,[Validators.required]] ,///min value 1
      //SubTotal:[{value: 0, disabled: true},[Validators.required]] 
    })



  }

  getAllCustomers(){
    this.accountsService.GetAccounts().subscribe(
      data=>{
        this.customers= data;
      },
      error=>{

      }
    )
  }

  getAllWarehouses(){
    this.warehousesService.GetWarehouses().subscribe(
      data=>{
        this.warehouses= data;
      },
      error=>{

      }
    )
  }

  getAllItems(){
    this.itemsService.GetItems().subscribe(
      data=>{
        this.items= data;
      },
      error=>{

      }
    )
  }

}
