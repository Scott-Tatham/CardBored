using UnityEngine;
using System.Collections;
namespace myEvents
{
    public class voidEvent
    {
        public static voidEvent operator +(voidEvent c1, voidEventDelegate c2)
        {
              c1.addEvent(c2);
              return c1;
        }

        

        public void run()
        {
            if (action != null)
            {
                action();
            }
        }
        public void addEvent(voidEventDelegate newEvent)
        {
            if (newEvent != null)
            {
                action += newEvent;
            }
        }
        public void clearStoredEvents()
        {
            action = null;
        }
       private voidEventDelegate action;
    }
    public delegate void voidEventDelegate();
}
