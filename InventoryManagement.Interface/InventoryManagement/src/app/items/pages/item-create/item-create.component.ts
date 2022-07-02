import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormArray, Validators } from '@angular/forms';
import { NotEmpty } from 'src/app/shared/validators/not-empty.validator';
import { ItemForCreation } from '../../../core/models/item-for-creation';
import { ItemImageForCreation } from '../../../core/models/item-image-for-creation';
import { ItemCategoriesService } from '../../../core/services/item-categories.service';
import { ItemCategory } from '../../../core/models/item-category';
import { ItemType } from '../../../core/models/enums/item-type';
import { itemTypeList } from '../../../core/models/item-types-list';
import { WarehousesService } from '../../../core/services/warehouses.service';
import { ContentHeaderService, ItemsService, Warehouse } from 'src/app/core';

@Component({
  selector: 'app-item-create',
  templateUrl: './item-create.component.html',
  styleUrls: ['./item-create.component.css']
})
export class ItemCreateComponent implements OnInit {

  itemForm: FormGroup;

  itemForCreation:ItemForCreation
  itemCategoriesList:ItemCategory[];
  itemTypes:any [];
  warehousesList:Warehouse[];


  constructor( private formBuilder: FormBuilder, private itemsService: ItemsService, private itemCategoriesService: ItemCategoriesService, private WarehousesService:WarehousesService,private contentHeaderService:ContentHeaderService) {
    this.itemTypes=itemTypeList;

    this.itemForm= formBuilder.group({
      code:['',[Validators.required, Validators.minLength(2), Validators.maxLength(5), NotEmpty]],
      name: ['',[Validators.required, Validators.minLength(4), Validators.maxLength(50), NotEmpty]],
      description:['',[Validators.maxLength(500)]],
      inroduction:[''],
      minPrice:[0],
      price:[0],
      totalQuantity:[0],
      itemType:[null,[Validators.required]],
      isActive:[true],
      itemCategoryId:[null,[Validators.required]],
      warehouseItems:this.formBuilder.array([]),
      itemImages:this.formBuilder.array([]),
      filesOfImages:[]
    })
  }

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("إضافة صنف جديد")
    this.getItemCategoriesList();
    this.getWarehousesList();
  }


  get warehouseItems(){
    return this.itemForm.get("warehouseItems") as FormArray;
  }

  get itemImages(){
    return this.itemForm.get("itemImages") as FormArray;
  }

  get code(){
    return this.itemForm.get('code');
  }

  get name(){
    return this.itemForm.get('name');
  }

  get description(){
    return this.itemForm.get('description');
  }

  get itemType(){
    return this.itemForm.get('itemType');
  }

  get itemCategoryId(){
    return this.itemForm.get('itemCategoryId');
  }

  newWarehouseItem(): FormGroup{
    return this.formBuilder.group({
      warehouseId:[null,[Validators.required]],
      quantity:[null,[Validators.required]]
    }) 
  }

  newItemImage(): FormGroup{
    return this.formBuilder.group({
      name:['',[Validators.required, Validators.minLength(4), Validators.maxLength(50), NotEmpty]],
      description:['',[ Validators.maxLength(500)]],
      fileInput:['',[Validators.required]]
    }) 
  }

  addNewWarehouseItem(){
    this.warehouseItems.push(this.newWarehouseItem());
  }

  addNewItemImage(){
    this.itemImages.push(this.newItemImage());
  }

  removeWarehouseItem(index: number){
    this.warehouseItems.removeAt(index);
  }

  removeItemImage(index: number){
    this.itemImages.removeAt(index);
  }

  getItemImageName(index: number){
    return this.itemImages.at(index).get("name");
  }

  getItemImageFileInput(index: number){
    return this.itemImages.at(index).get("fileInput");
  }

  getWarehouseItemId(index: number){
    return this.warehouseItems.at(index).get("warehouseId");
  }

  getWarehouseItemQuantity(index: number){
    return this.warehouseItems.at(index).get("quantity");
  }

  uploadedImages:File[]=[];
  onFileChange(event,index){
    console.log(event)
    if(event.target.files.length>0){
      console.log("event")
      const file=event.target.files[0];
      this.uploadedImages.push(file);

      this.itemForm.patchValue({
        filesOfImages:this.uploadedImages
      });
      
    }
     
  }

  onSubmit(){
    console.log(this.itemForm.value);
    this.itemForCreation=new ItemForCreation(this.itemForm.value);
    console.log(this.itemForCreation)

    this.itemsService.addItem(this.itemForCreation)
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

  getItemCategoriesList(){
    this.itemCategoriesService.GetItemCategories().subscribe(
      data=>{
        this.itemCategoriesList=data;
      },
      error=>{

      }
    )    
  }

  getWarehousesList(){
    this.WarehousesService.GetWarehouses().subscribe(
      data=>{
        this.warehousesList=data;
      },
      error=>{

      }
    )    
  }


}
