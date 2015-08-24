using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IObservableNS
{
    public struct Location
    {
        double lat, lon;

        public Location(double latitude, double longitude)
        {
            this.lat = latitude;
            this.lon = longitude;
        }

        public double Latitude
        { get { return this.lat; } }

        public double Longitude
        { get { return this.lon; } }
    }

    public class LocationTracker : IObservable<Location>
    {
        private List<IObserver<Location>> observers;

        public LocationTracker()
        {
            observers = new List<IObserver<Location>>();
        }

        public IDisposable Subscribe(IObserver<Location> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Location>> _observers;
            private IObserver<Location> _observer;

            public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void TrackLocation(Nullable<Location> loc)
        {
            foreach (var observer in observers)
            {
                if (!loc.HasValue)
                    observer.OnError(new ArgumentNullException());
                else
                    observer.OnNext(loc.Value);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }
}
