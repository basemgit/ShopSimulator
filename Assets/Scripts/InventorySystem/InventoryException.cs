using System;

namespace InventorySystem
{
    public enum InventoryOperation
    { 
      ADD,
      REMOVE
    }
    public class InventoryException : Exception
    {
        public InventoryOperation Operation { get; }
        public InventoryException(InventoryOperation operation,string msg):base($"{operation} Error: {msg}") 
        {
          Operation = operation;
        }
    }
}