import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class EntryService {
  constructor(private http: HttpClient) {}

  getEntries() {
    return this.http.get("/api/entries");
  }

  getColors() {
    return this.http.get("api/entry-colors");
  }

  create(entry) {
    return this.http.post("/api/entries", entry);
  }

  getStats() {
    return this.http.get("/api/entries/stats");
  }
}
