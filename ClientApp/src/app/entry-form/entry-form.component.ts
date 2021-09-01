import { EntryService } from "./../services/entry.service";
import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-entry-form",
  templateUrl: "./entry-form.component.html",
  styleUrls: ["./entry-form.component.css"],
})
export class EntryFormComponent implements OnInit {
  colors;
  entryForm: FormGroup;
  submitted: Boolean = false;

  constructor(
    private entryService: EntryService,
    private formBuilder: FormBuilder,
    private toasterService: ToastrService
  ) {
    this.entryForm = formBuilder.group({
      first_name: new FormControl(
        null,
        Validators.compose([Validators.required, Validators.maxLength(255)])
      ),
      last_name: new FormControl(
        null,
        Validators.compose([Validators.required, Validators.maxLength(255)])
      ),
      age: new FormControl(
        null,
        Validators.compose([Validators.required, Validators.min(1)])
      ),
      favorite_color: new FormControl(
        null,
        Validators.compose([Validators.required, Validators.maxLength(100)])
      ),
      new_color: new FormControl(
        null,
        Validators.compose([Validators.required, Validators.maxLength(100)])
      ),
    });
  }

  ngOnInit() {
    this.entryService.getColors().subscribe((res) => {
      this.colors = res;
      //console.log(this.colors);
    });
  }

  onColorChange() {
    if (this.entryForm.get("favorite_color").value === "Other") {
      this.entryForm.controls["new_color"].setValidators([
        Validators.required,
        Validators.maxLength(100),
      ]);
      this.entryForm.controls["new_color"].updateValueAndValidity();
    } else {
      this.entryForm.controls["new_color"].setValidators([]);
      this.entryForm.controls["new_color"].setValue("");
      this.entryForm.controls["new_color"].updateValueAndValidity();
    }
  }

  onSubmit() {
    this.submitted = true;
    let entry = this.buildData();
    if (this.entryForm.valid) {
      this.entryService.create(entry).subscribe(
        (res) => {
          //console.log(res);
          this.toasterService.success(
            "Successfully submitted your entry!",
            "Success"
          );
        },
        (err) => {
          this.submitted = false;
          this.toasterService.error("An unexpected error happened.", "Error", {
            timeOut: 5000,
          });
        }
      );
    }
  }

  buildData() {
    return {
      FirstName: String(this.entryForm.get("first_name").value).trim(),
      LastName: String(this.entryForm.get("last_name").value).trim(),
      Age: this.entryForm.get("age").value,
      Color:
        this.entryForm.get("favorite_color").value === "Other"
          ? String(this.entryForm.get("new_color").value).trim()
          : String(this.entryForm.get("favorite_color").value).trim(),
    };
  }
}
