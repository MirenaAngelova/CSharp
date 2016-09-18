﻿namespace Blobs2.Models.Events
{
    using System;

    public class BlobDeadEventArgs : EventArgs
    {
        public BlobDeadEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
