import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { CardComponent } from './components/card/card.component';
import { DeckComponent } from './components/deck/deck.component';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CardCreateComponent } from './components/card-create/card-create.component';
import { Ng2FittextModule } from 'ng2-fittext';
import { FileUploadModule } from 'primeng/fileupload';
import { DropdownModule } from 'primeng/dropdown';
import { RatingModule } from 'primeng/rating';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastModule } from 'primeng/toast';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { ConfirmationService, MessageService } from 'primeng/api';
import { MenubarComponent } from './components/menubar/menubar.component';
import { MenubarModule } from 'primeng/menubar';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { RegistrationFormComponent } from './components/registration-form/registration-form.component';
import { GameComponent } from './components/game/game.component';
import { RpsGameComponent } from './components/rps-game/rps-game.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { Error404Component } from './components/error404/error404.component';
import { WelcomePageComponent } from './components/welcome-page/welcome-page.component';
import { UploadFileComponent } from './components/upload-file/upload-file.component';
import { TestComponent } from './components/test/test.component';
import { LoadinscreenComponent } from './components/loadinscreen/loadinscreen.component';
import { ProgressBarModule } from 'primeng/progressbar';
import { AnimateModule } from 'primeng/animate';
import { DeckCreateComponent } from './components/deck-create/deck-create.component';
import { SplitButtonModule } from 'primeng/splitbutton';
import { PaginatorModule } from 'primeng/paginator';
import { CardsComponent } from './components/cards/cards.component';
import { RulesComponent } from './components/rules/rules.component';

@NgModule({
  declarations: [
    AppComponent,
    CardComponent,
    DeckComponent,
    CardCreateComponent,
    MenubarComponent,
    LoginFormComponent,
    HomeComponent,
    RegistrationFormComponent,
    GameComponent,
    RpsGameComponent,
    UserProfileComponent,
    Error404Component,
    WelcomePageComponent,
    UploadFileComponent,
    TestComponent,
    LoadinscreenComponent,
    DeckCreateComponent,
    CardsComponent,
    RulesComponent,
  ],
  imports: [
    BrowserModule,
    PaginatorModule,
    ProgressBarModule,
    AppRoutingModule,
    ButtonModule,
    InputTextModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    Ng2FittextModule,
    FileUploadModule,
    DropdownModule,
    RatingModule,
    BrowserAnimationsModule,
    ToastModule,
    ConfirmDialogModule,
    MessagesModule,
    MessageModule,
    MenubarModule,
    AnimateModule,
    SplitButtonModule,
  ],
  providers: [
    AppComponent,
    MessageService,
    ConfirmationService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
