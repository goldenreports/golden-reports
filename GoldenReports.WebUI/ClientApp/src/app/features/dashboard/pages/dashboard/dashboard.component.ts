import { Component } from '@angular/core';

@Component({
  templateUrl: 'dashboard.component.html',
  styleUrls: ['dashboard.component.scss']
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
