using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PusherServer;
using System.Net;
using System.Threading.Tasks;


namespace main.Controllers
{
    public class webSocketController {
        string chanel ="anhlatuananh";
        string Event="Neworder";
        public async Task<ActionResult> webSocket(object obj) {
            var options = new PusherOptions
            {
            Cluster = "ap3",
            Encrypted = true
            };

            var pusher = new Pusher(
            "1226220",
            "0c74ee77eb82bc0b814a",
            "92a74fdbbaf3692d0093",
            options);

            var result = await pusher.TriggerAsync(
            chanel,
            Event,
            new { message = obj} );

            return null;
        }

    }
}