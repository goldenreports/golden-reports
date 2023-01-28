import { Component } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { HttpClient } from '@angular/common/http';

@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent {
  initLoading = true; // bug
  loadingMore = false;
  data: any[] = [];
  list: Array<{ loading: boolean; name: any }> = [];

  ngOnInit(): void {
    this.getData((res: any) => {
      this.data = res.results;
      this.list = res.results;
      this.initLoading = false;
    });
  }

  getData(callback: (res: any) => void): void {
    // this.http
    //   .get(fakeDataUrl)
    //   .pipe(catchError(() => of({ results: [] })))
    //   .subscribe((res: any) => callback(res));
  }

  onLoadMore(): void {
    // this.loadingMore = true;
    // this.list = this.data.concat([...Array(count)].fill({}).map(() => ({ loading: true, name: {} })));
    // this.http
    //   .get(fakeDataUrl)
    //   .pipe(catchError(() => of({ results: [] })))
    //   .subscribe((res: any) => {
    //     this.data = this.data.concat(res.results);
    //     this.list = [...this.data];
    //     this.loadingMore = false;
    //   });
  }

  edit(item: any): void {
  }
}
