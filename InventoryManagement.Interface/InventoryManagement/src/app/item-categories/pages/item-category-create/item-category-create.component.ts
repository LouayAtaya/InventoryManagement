import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { NotEmpty } from '../../../shared/validators/not-empty.validator';
import { ItemCategoryForCreation } from '../../../core/models/item-category-for-creation';
import { ItemCategoriesService } from '../../../core/services/item-categories.service';
import { error } from '@angular/compiler/src/util';
import { ContentHeaderService } from 'src/app/core';

@Component({
  selector: 'app-item-category-create',
  templateUrl: './item-category-create.component.html',
  styleUrls: ['./item-category-create.component.css']
})
export class ItemCategoryCreateComponent implements OnInit {

  itemCategoryForm= new FormGroup({
    'name':new FormControl('',[Validators.required, Validators.minLength(4), Validators.maxLength(50), NotEmpty]),
    'description':new FormControl('',[ Validators.maxLength(500)]),
    'image':new FormControl(),
    'isActive':new FormControl(true),
    'parentCategoryId':new FormControl(''),
    'imageFile':new FormControl(),
    'fileInput':new FormControl('',[Validators.required]),
    'childCategories': new FormArray([])
  })

  constructor(public itemCategoriesService : ItemCategoriesService,private contentHeaderService:ContentHeaderService) {

  }

  ngOnInit(): void {
    this.contentHeaderService.setMainHeaderTitle("إضافة تصنيف جديد")
  }

  get name(){
    return this.itemCategoryForm.get('name');
  }

  get description(){
    return this.itemCategoryForm.get('description');
  }

  get fileInput(){
    return this.itemCategoryForm.get('fileInput');
  }

  get childCategories(){
    return this.itemCategoryForm.get("childCategories") as FormArray
  }

  newChildCategory(){
    return new FormGroup({
      'name':new FormControl('',[Validators.required, Validators.minLength(4), Validators.maxLength(50), NotEmpty]),
      'description':new FormControl('',[Validators.maxLength(500)]),
      'image':new FormControl(),
      'isActive':new FormControl(true),
      'parentCategoryId':new FormControl(''),
      'childItemCategories': new FormArray([])
    })
  }

  addNewChildCategory(){
    this.childCategories.push(this.newChildCategory())
  }

  removeChildCategory(index:number){
    this.childCategories.removeAt(index);
  }

  getChildCategoryName(index:number){
    return this.childCategories.at(index).get("name");
  }

  getChildCategoryDescription(index:number){
    return this.childCategories.at(index).get("description");
  }
  
  itemCategoryForCreation:ItemCategoryForCreation;

  onFileChanged(event) {
    console.log(event)
    if (event.target.files.length > 0) {
      console.log("event")
      const file = event.target.files[0];
      this.itemCategoryForm.patchValue({
        imageFile: file,
      });
    }
  }

  

  onSubmit(){
    this.itemCategoryForCreation=this.itemCategoryForm.value 
    console.log(this.itemCategoryForCreation)
    
    this.itemCategoriesService.addItemCategory(this.itemCategoryForCreation)
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
