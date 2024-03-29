import { Component, OnDestroy, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Subscription, timer } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { SignalrService } from 'src/app/services/signalr.service';
import { RpsGameService } from 'src/app/services/rps-game.service';
import { IngameService } from 'src/app/services/ingame.service';

@Component({
  selector: 'app-rps-game',
  templateUrl: './rps-game.component.html',
  styleUrls: ['./rps-game.component.css'],
})
export class RpsGameComponent implements OnInit, OnDestroy {
  imgpath = 'https://localhost:7250/Resources/Images/';

  options: any[] = [
    { name: 'Rock', choosen: false },
    { name: 'Paper', choosen: false },
    { name: 'Scissors', choosen: false },
  ];
  enemiesOptions: any[] = [
    { name: 'Rock', choosen: true },
    { name: 'Paper', choosen: true },
    { name: 'Scissors', choosen: true },
  ];

  progressValue!: number;
  loadingBar = 100;
  rpsGameStarted: Boolean = false;
  timerCountDown: any;
  progress: any;
  message = 'Choose your option';
  userID = this.authService?.userValue?.id;

  isDisebled = false;
  rpsGameID!: number;
  playerID: any;
  enemiePlayerID: any;
  isLoadingOver = false;
  loadingType = 'rpsGame';
  gameID: any;
  winner: any;
  user: any;
  subscriptions: Subscription[] = [];

  constructor(
    private route: ActivatedRoute,
    private signalrService: SignalrService,
    public inGameService: IngameService,
    private authService: AuthService,
    private rpsGameService: RpsGameService,
    private messageService: MessageService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.rpsGameID = this.route.snapshot.params['rpsGameID'];
    console.log(Number(this.rpsGameID));
    this.setGameStatus();
    this.getRpsGame();
    this.progressValue = 0;
    this.getRPSWinner();
  }
  getRpsGame() {
    this.subscriptions.push(
      this.rpsGameService.getRPSGame(this.rpsGameID, this.userID).subscribe({
        next: (res: any) => {
          this.playerID = res.playerID;
          this.enemiePlayerID = res.enemiePlayerID;
          this.gameID = res.gameID;
          this.setNewUserValue();
        },
        error: (err) => {
          console.log(err);
        },
      })
    );
  }
  setNewUserValue() {
    this.user = {
      ...this.authService.userValue,
      enemie: this.enemiePlayerID,
      player: this.playerID,
    };
    localStorage.setItem('user', JSON.stringify(this.user));
    this.authService.userSubject.next(this.user);
    console.log(this.authService.userValue);
  }
  chooseRPSMove(move: string) {
    this.subscriptions.push(
      this.rpsGameService.playRPSMove(this.playerID, move).subscribe({
        next: (res: any) => {
          this.filterOptions(move, this.options);
          this.messageService.add({
            key: 'br',
            severity: 'success',
            summary: 'Success',
            detail: 'You choose ' + move,
          });
        },
        error: (err) => {
          this.messageService.add({
            key: 'br',
            severity: 'error',
            summary: 'Error',
            detail: err.error,
          });
        },
      })
    );
  }

  getTimer(event: any) {
    console.log('ovdeee', event);
    this.isLoadingOver = event;
    this.progressionFunction();
  }

  filterOptions(option: any, options: any[]) {
    options.forEach((element) => {
      if (element.name !== option) {
        element.choosen = true;
      } else {
        element.choosen = false;
        this.isDisebled = true;
      }
    });
  }
  checkRPSWinnerInv(): void {
    this.signalrService.hubConnection
      .invoke('CheckRPSWinner', Number(this.rpsGameID))
      .catch((err) => console.error(err));
  }

  getRPSWinner() {
    this.signalrService.hubConnection.on('GetRPSWinner', (winner: any) => {
      this.winner = winner;

      this.getEnemiesMove();
      this.generateMessage();
      console.log(winner);
    });
  }
  generateMessage() {
    // console.log(winner)
    this.loadingBar = 0;

    if (this.winner === this.playerID) {
      this.message = 'You win';
      clearInterval(this.progress);
      setTimeout(() => {
        this.router.navigate(['/game', this.gameID]);
      }, 3000);
    } else if (this.winner === this.enemiePlayerID) {
      this.message = 'You lose';
      clearInterval(this.progress);
      setTimeout(() => {
        this.router.navigate(['/game', this.gameID]);
      }, 3000);
    } else if (this.winner == 0) {
      console.log('W I N N E R ', this.winner);
      this.message = 'Draw';
      this.enemiesOptions.forEach((element) => {
        element.choosen = true;
      });
      clearInterval(this.progress);
      this.progressionFunction();
    }
  }

  getEnemiesMove() {
    this.subscriptions.push(
      this.rpsGameService.getPlayerMove(this.enemiePlayerID).subscribe({
        next: (res: any) => {
          console.log(res);
        },
        error: (err) => {
          this.filterOptions(err.error.text, this.enemiesOptions);

          console.log(err.error.text);
        },
      })
    );
  }

  progressionFunction() {
    this.progressValue = 0;
    let progressEndValue = 100;
    let speed = 150;
    this.loadingBar = 100;
    clearInterval(this.progress);
    this.progress = setInterval(() => {
      this.progressValue++;
      console.log(this.progressValue);
      this.loadingBar = this.loadingBar - 1;
      if (this.progressValue == progressEndValue) {
        clearInterval(this.progress);
        this.checkRPSWinnerInv();
      }
      speed = 150;
    }, speed);
    // clearInterval(this.progress);
  }

  setGameStatus() {
    this.inGameService.setGameOn();
  }
  
  ngOnDestroy(): void {
    clearInterval(this.progress);
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
    this.signalrService.hubConnection.off('GetRPSWinner');
  }
}
