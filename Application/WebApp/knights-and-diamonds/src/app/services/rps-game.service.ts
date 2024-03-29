import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpEventType,
  HttpHeaders,
} from '@angular/common/http';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { SignalrService } from './signalr.service';
import { Router } from '@angular/router';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};

@Injectable({
  providedIn: 'root',
})
export class RpsGameService {
  constructor(
    private httpClient: HttpClient,
    private signalrService: SignalrService,
    private router: Router
  ) {}

  startGameInv(rpsGameID: any) {
    this.signalrService.hubConnection
      .invoke('StartRPSGame', rpsGameID)
      .catch((err) => console.error(err));
  }

  startGame(lobbyID: any) {
    return this.httpClient.post(
      `https://localhost:7250/RPSGame/StartGame/` + `${lobbyID}`,
      { responseType: 'text' }
    );
  }

  denyGame(lobbyID: any) {
    console.log(lobbyID);
    return this.httpClient.delete(
      `https://localhost:7250/RPSGame/DenyGame/` + `${lobbyID}`
    );
  }

  getPlayer(rpsGameID: any, userID: any) {
    return this.httpClient.get(
      `https://localhost:7250/RPSGame/GetPlayer/` +
        `${rpsGameID}` +
        `/` +
        `${userID}`
    );
  }
  getPlayerMove(playerID: any) {
    return this.httpClient.get(
      `https://localhost:7250/RPSGame/GetPlayerMove/` + `${playerID}`
    );
  }
  getRPSGame(rpsGameID: any, userID: any) {
    return this.httpClient.get(
      `https://localhost:7250/RPSGame/GetRPSGame/` +
        `${rpsGameID}` +
        `/` +
        `${userID}`
    );
  }
  removeUserFromUsersInGame(userID: any) {
    return this.httpClient.delete(
      `https://localhost:7250/RPSGame/RemoveUserFromUsersInGame/` + `${userID}`
    );
  }

  playRPSMove(playerID: any, moveName: string) {
    return this.httpClient.put(
      `https://localhost:7250/RPSGame/PlayMove/` +
        `${playerID}` +
        `/` +
        `${moveName}`,
      { responseType: 'text' }
    );
  }
}
