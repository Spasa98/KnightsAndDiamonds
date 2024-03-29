import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit, OnDestroy {
  
    form!: FormGroup;
    subscriptions: Subscription[] = [];
    submitted = false;
    
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private messageService: MessageService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
  });
  }

  onSubmit(){
    const userData = this.form.getRawValue();
    this.subscriptions.push(
      this.authService.login(userData).subscribe({
        next: (res: any)=>{
          this.router.navigate(['/home']);
          this.messageService.add({key: 'br', severity:'success', summary: 'Uspešno', detail: 'Prijava je uspela!'});
          console.log("ovdee",this.authService?.userValue?.id);`1`
        },
        error: err=>{
          this.messageService.add({key: 'br', severity:'error', summary: 'Neuspešno', detail: 'Pokušajte ponovo, došlo je do greške.'});
        }
      })
    )
  }

  onSignUp(){
    
  }

  onMouseEnter(hoverName: HTMLElement) {
    hoverName.style.color = "blue";
  }

  onMouseOut(hoverName: HTMLElement) {
    hoverName.style.color = "black";
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }
  
}
