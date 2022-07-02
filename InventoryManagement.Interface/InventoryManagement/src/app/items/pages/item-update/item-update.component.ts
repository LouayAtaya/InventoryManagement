import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContentHeaderService, ItemCategoriesService, ItemCategory, ItemsService, Warehouse } from 'src/app/core';
import { itemTypeList } from 'src/app/core/models/item-types-list';
import { NotEmpty } from 'src/app/shared/validators/not-empty.validator';
import { ItemForUpdate } from '../../../core/models/item-for-update';
import { WarehousesService } from '../../../core/services/warehouses.service';
import { ItemDetails } from '../../../core/models/item-details';

@Component({
  selector: 'app-item-update',
  templateUrl: './item-update.component.html',
  styleUrls: ['./item-update.component.css']
})
export class ItemUpdateComponent implements OnInit {
  itemId:number;
  itemDetails:ItemDetails;

  itemForm: FormGroup;

  itemForUpdate:ItemForUpdate
  itemCategoriesList:ItemCategory[];
  itemTypes:any [];
  warehousesList:Warehouse[];
  
  constructor( private formBuilder: FormBuilder, private itemsService: ItemsService, private itemCategoriesService: ItemCategoriesService, private warehousesService:WarehousesService,private route:ActivatedRoute,private router: Router,private contentHeaderService:ContentHeaderService) {
    this.itemTypes=itemTypeList;

    this.itemForm= formBuilder.group({
      id:[],
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
    this.getItemCategoriesList();
    this.getWarehousesList();

    this.route.paramMap.subscribe(
      params=>{
        this.itemId=Number.parseInt(params.get("id")) 

        this.initializeFormWithItem(this.itemId)
      }
    )
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
      itemId:[],
      quantity:[null,[Validators.required]]
    }) 
  }

  newItemImage(): FormGroup{
    return this.formBuilder.group({
      id:[],
      name:['',[Validators.required, Validators.minLength(4), Validators.maxLength(50), NotEmpty]],
      description:['',[ Validators.maxLength(500)]],
      url:[''],
      itemId:[],
      fileInput:['',[Validators.required]]
    }) 
  }

  

  addNewWarehouseItem(){
    this.warehouseItems.push(this.newWarehouseItem());
  }

  addNewItemImage(){
    this.itemImages.push(this.newItemImage());
  }

  addNewItemImageDisabledFields(){
    let itemImageElement= this.newItemImage();
    itemImageElement.get("fileInput").disable({onlySelf:true});
    this.itemImages.push(itemImageElement);
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

  getItemImageUrl(index: number){
    return this.itemImages.at(index).get("url");
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
    this.itemForUpdate=new ItemForUpdate(this.itemForm.value);
    console.log(this.itemForUpdate)

    this.itemsService.UpdateItem(this.itemId,this.itemForUpdate)
      .subscribe(
        data=>{
          alert("updated");
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
    this.warehousesService.GetWarehouses().subscribe(
      data=>{
        this.warehousesList=data;
      },
      error=>{

      }
    )    
  }

  initializeFormWithItem(id:number){
    this.itemsService.GetItemDetails(id).subscribe(
      data=>{
        this.itemDetails=data;
        
        this.contentHeaderService.setMainHeaderTitle(this.itemDetails.name)
        //this.itemDetails.filesOfImages=[]

        this.itemDetails.warehouseItems.forEach(element=>{
            element.itemId=this.itemDetails.id;
            this.addNewWarehouseItem();
          }
        )

        this.itemDetails.itemImages.forEach(element=>{
            element.itemId=this.itemDetails.id;
            this.addNewItemImageDisabledFields();
          }
        )
        

        //this.itemForm.setValue(this.itemDetails)
        this.itemForm.patchValue({
          id:this.itemDetails.id,
          code:this.itemDetails.code,
          name:this.itemDetails.name,
          description:this.itemDetails.description?this.itemDetails.description:'',
          inroduction:this.itemDetails.inroduction,
          minPrice:this.itemDetails.minPrice,
          price:this.itemDetails.price,
          totalQuantity:this.itemDetails.totalQuantity,
          itemType:this.itemDetails.itemType,
          isActive:this.itemDetails.isActive,
          itemCategoryId:this.itemDetails.itemCategoryId,
          warehouseItems:this.itemDetails.warehouseItems,
          itemImages:this.itemDetails.itemImages
        })

      },
      error=>{

      }
    )
  }

  initializeWarehouseItemsForm(){
    this.itemDetails.warehouseItems.forEach(element => {
      this.addNewWarehouseItem();
    });
  }

  initializeItemImagesForm(){
    this.itemDetails.itemImages.forEach(element => {
      this.addNewItemImage();
    });
  }

}
