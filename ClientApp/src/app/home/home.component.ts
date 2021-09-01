import { Component, OnInit } from "@angular/core";
import { EntryService } from "../services/entry.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
})
export class HomeComponent implements OnInit {
  records: [] = [];
  stats: [] = [];
  constructor(private entryService: EntryService) {}

  ngOnInit() {
    this.entryService.getEntries().subscribe((res: []) => {
      this.records = res;
    });

    this.entryService.getStats().subscribe((res: []) => {
      this.stats = res;
      //console.log(this.stats);
    });
  }
}
