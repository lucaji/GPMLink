using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace GPMLib {

    [DataContract]
    public class PowerTargetValueViewModel : IEquatable<PowerTargetValueViewModel?>, IComparable<PowerTargetValueViewModel> {

        public static List<PowerTargetValueViewModel>Defaults {
            get {
                var results = new List<PowerTargetValueViewModel>();
                results.Add(new PowerTargetValueViewModel(0.25));
                results.Add(new PowerTargetValueViewModel(0.5));
                results.Add(new PowerTargetValueViewModel(0.75));
                results.Add(new PowerTargetValueViewModel(1));
                return results;
            } 
        }

        [DataMember]
        public double Percentage { get; private set; }

        public string PercentageString { get => (Percentage * 100).ToString("0.#") + "%"; }

        public string FoundValueString { get; private set; } = string.Empty;

        public string FoundTimeString { get; private set; } = string.Empty;

        public static PowerTargetValueViewModel? Factory(double p) {
            if (p < 0) { return null; }
            if (p > 1) { return null; }
            return new PowerTargetValueViewModel(p);
        }

        public PowerTargetValueViewModel(double p) {
            Percentage = p;
        }

        public void UpdateWith(string v, string t) {
            FoundValueString = v;
            FoundTimeString = t;
        }

        public override bool Equals(object? obj) {
            return Equals(obj as PowerTargetValueViewModel);
        }

        public bool Equals(PowerTargetValueViewModel? other) {
            return other != null &&
                   Percentage == other.Percentage;
        }

        public override int GetHashCode() {
            return 355317789 + Percentage.GetHashCode();
        }

        public int CompareTo(PowerTargetValueViewModel other) {
            return this.Percentage.CompareTo(other.Percentage);
        }

        public override string ToString() {
            return PercentageString;
        }
    }
}
