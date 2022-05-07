import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { NotEmpty } from '../../../shared/validators/not-empty.validator';
import { ItemCategoryForCreation } from '../../../core/models/item-category-for-creation';

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
    'parentCategoryId':new FormControl(),
    'childCategories': new FormArray([])
  })

  constructor() {

  }

  ngOnInit(): void {
  }

  get name(){
    return this.itemCategoryForm.get('name');
  }

  get description(){
    return this.itemCategoryForm.get('description');
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
      'parentCategoryId':new FormControl(),
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

  onSubmit(){
    this.itemCategoryForCreation=this.itemCategoryForm.value as ItemCategoryForCreation;
    console.log(this.itemCategoryForm.value)
    
  }

  

  

}
