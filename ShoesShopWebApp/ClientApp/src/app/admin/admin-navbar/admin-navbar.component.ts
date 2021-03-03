import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
declare var $: any;


@Component({
  selector: 'app-admin-navbar',
  templateUrl: './admin-navbar.component.html',
  styleUrls: ['./admin-navbar.component.css']
})
export class AdminNavBarComponent {
  isExpanded = false;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, router: Router) {
  }
  ngOnInit() {
    this.account = sessionStorage.getItem('admin');
    this.isLogin = Boolean(JSON.parse(sessionStorage.getItem('adminLogin')));
    console.log(this.account);
    if (sessionStorage.getItem('customer') != null){
      this.isCustomer = true;
    }
    else{
      this.isCustomer = false;
    }
  }
  //#region "Khai báo các biến"
  router: Router
  isCustomer: Boolean = false;
  account: String = ""
  isLogin: Boolean = false;
  data: any = {
    account: "",
    pass: ""
  }
  req: any ={
    account: "",
    status: ""
  }
  //#endregion "Khai báo các biến"


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  openLoginModal() {
    $('#LoginModal').modal('show');
  }
  checkLogin() {this.http.post('https://localhost:44343/api/Employee/Login', this.data).subscribe(
      result => {
        this.req = result;
        if (this.req.status == 1){
          alert("Tài khoản bị vô hiệu hóa !")
        }
        else{
          if (this.req.account != "") {
            this.isLogin = true;
            sessionStorage.setItem('admin', this.data.account);
            sessionStorage.setItem('adminLogin', "true")
            window.location.href=window.location.href;
            this.toggleLoginModal();
          }
          else {
            alert("Tài khoản hoặc mật khẩu không đúng !")
          }
        }
      },
      error => {
        alert("Server error !!!")
      })
  }

  logout(){
    sessionStorage.setItem('adminLogin', "false");
    sessionStorage.removeItem('admin');
    this.router.navigate(['/admin']);
  }

  toggleLoginModal() {
    $('#LoginModal').modal('hide');
  }

  // getAccountSession() {this.http.get<any>('https://localhost:44343/api/Employee/getEmployeeSession').subscribe(
  //     result => {
  //       console.log(result);
  //       var res: any = result;
  //       if (res != null) {
  //         this.userLogin = res;
  //         this.isLogin = true;
  //       }
  //     },
  //     error => {
  //       alert("Error !!")
  //     });
  // }
}
//#region "JavaSrcipt"
//#endregion "JavaSrcipt"