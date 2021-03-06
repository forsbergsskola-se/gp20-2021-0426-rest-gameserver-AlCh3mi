using System;

namespace LameScooter.Rentals.Data {
    public class NotFoundException : Exception {
        
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception e) : base(message, e) { }
    }
}