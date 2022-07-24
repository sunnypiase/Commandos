using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Commandos.TxtSerialize
{
    internal class TXTSerializedParameters : IDictionary<string, string>
    {
        #region Props
        public string PrimalLine { get; set; }
        private Dictionary<string, string> _parameters;
        #endregion
        #region Ctors
        public TXTSerializedParameters()
        {
            _parameters = new();
        }
        public TXTSerializedParameters(Dictionary<string, string> parameters)
        {
            _parameters = new(parameters);
        }
        public TXTSerializedParameters(Dictionary<string, string> parameters, string primalLine) : this(parameters)
        {
            PrimalLine = primalLine;
        }
        public TXTSerializedParameters(TXTSerializedParameters other) : this(other._parameters, other.PrimalLine)
        { }
        #endregion
        #region IDictionary

        public string this[string key]
        {
            get => _parameters[key];
            set => _parameters[key] = value;
        }

        public ICollection<string> Keys => _parameters.Keys;

        public ICollection<string> Values => _parameters.Values;

        public int Count => _parameters.Count;

        public bool IsReadOnly => false;

        public void Add(string key, string value)
        {
            _parameters.Add(key, value);
        }

        public void Add(KeyValuePair<string, string> item)
        {
            _parameters.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _parameters.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return _parameters.ContainsKey(item.Key);
        }

        public bool ContainsKey(string PropName)
        {
            return _parameters.ContainsKey(PropName);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        public bool Remove(string key)
        {
            return _parameters.Remove(key);
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return _parameters.Remove(item.Key);
        }
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            return _parameters.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region ObjectOverrides
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> item in _parameters)
            {
                sb.Append($"<{item.Key}: {item.Value}>;");
            }
            return sb.ToString();
        }
        #endregion

    }
}
