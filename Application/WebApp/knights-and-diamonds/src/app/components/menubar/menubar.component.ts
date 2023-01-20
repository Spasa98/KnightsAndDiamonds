import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConfirmationService, MenuItem } from 'primeng/api';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { OnelineusersService } from 'src/app/services/onelineusers.service';

@Component({
  selector: 'app-menubar',
  templateUrl: './menubar.component.html',
  styleUrls: ['./menubar.component.css']
})
export class MenubarComponent implements OnInit {

  subscriptions: Subscription[] = [];
  items!: MenuItem[];
  admin: any = " ";
  player: any = " ";
  id!: number;

  constructor(
    public authService: AuthService,
    private router: Router,
    private confirmationService: ConfirmationService,
    public onelineusers:OnelineusersService)
  { }

  ngOnInit(): void {

    console.log("ovdee user value:",this.authService.userValue)

    this.authService.loginStatusChange().subscribe(userSubject=>{

      this.items = [
        {
            label: 'Homepage', routerLink:['/home']
        },
        {
            label: 'Cards'
        },
        {
            label: 'Rules'
        },
      ];
    })
  }

  onClick()
  {
    this.confirmationService.confirm({
      message: 'Are you sure you want to log out?',
      accept: () => {
        this.authService.logout();
        console.log('OVO JE IZ HOME',this.authService.userValue)
        
        this.router.navigate(['/home']);
      }
    });
  }

  onLogin()
  {
    
  }

}
