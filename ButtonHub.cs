using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

public class ButtonHub : Hub
{
    public async Task StartProcess()
    {
        // Generate a random process duration
        Random rnd = new Random();
        int duration = rnd.Next(5000, 10001); // Random duration between 5000ms (5s) and 10000ms (10s)

        // Notify the client about the process start and send the duration
        await Clients.Caller.SendAsync("ProcessStarted", duration);

        // Wait for the process to complete
        await Task.Delay(duration);

        // Notify the client that the process is done
        await Clients.Caller.SendAsync("ProcessCompleted");
    }
}
