﻿namespace ProductStore.Web.Middleware
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

}
