import { ToastService } from 'src/app/service/toast/toast.service';
import { Injectable } from '@angular/core';
import * as signalr from '@microsoft/signalr';
@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  private hubConnection: signalr.HubConnection;

  constructor(
    private toastSV: ToastService
  ) {
    const token = localStorage.getItem("AccessToken") ?? "";
    this.hubConnection = new signalr.HubConnectionBuilder()
      .withUrl("https://localhost:5001/notification", {
        skipNegotiation: true,
        transport: signalr.HttpTransportType.WebSockets,
        accessTokenFactory: () => token
      })
      .configureLogging(signalr.LogLevel.Information)
      .withAutomaticReconnect()
      .build();
  }

  startConnection() {
    this.hubConnection
      .start()
      .then(() => console.log("Connection started!"))
      .catch(err => console.log("error:" + err));
  }

  addListener() {
    this.hubConnection.on("notify", (data) => {
      this.handleNotifyResponse(data);
    })
  }

  disconnect() {
    this.hubConnection.off("notify");
    this.hubConnection.stop();
  }

  askServer(data: any) {
    this.hubConnection.invoke("AskServer", data)
      .catch(err => {
        console.log(err);
      });
  }

  handleNotifyResponse(data: any) {
    switch(data.EventName) {
      case "REMIND_WORK":
        const now = new Date();
        const minuteLeft = new Date(data.DueDate).getMinutes() - now.getMinutes();
        const msg = `The task ${data.TaskCode} assigned to you is due in ${minuteLeft} minutes!`
        this.toastSV.showWarning(msg, "Dealine task", {
          timeOut: 8000,
          progressBar: true,
          progressAnimation: 'decreasing',
          positionClass: 'toast-bottom-right'
        });
        break;
      case "ASSIGN_TASK":
        this.toastSV.showWarning(data.Content, "Assign task", {
          timeOut: 8000,
          progressBar: true,
          progressAnimation: 'decreasing',
          positionClass: 'toast-bottom-right'
        });
        break;
    }
  }
}
