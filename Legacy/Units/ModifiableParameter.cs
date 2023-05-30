using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Units
{
    public class ModifiableParameter
    {
        public float RawValue { get; private set; }
        private float cachedValue;
        private float multipliedModifiersValue=1;
        private float addedModifiersValue=0;
        public float Get => cachedValue;

        public float GetSqr => (cachedValue * cachedValue);

        public ModifiableParameter(float rawValue)
        {
            RawValue = rawValue;
        }
        private HashSet<Modifier> modifiers = new HashSet<Modifier>();
        private void Recalculate(Modifier modifier)
        {
            if (modifier.operation == Modifier.Operation.Add)
            {
                PerformAddOperation(modifier.value);
            }
            else
            {
                PerformMultiplyOperation(modifier.value);
            }
            CalculateCachedValue();
        }

        private void CalculateCachedValue()
        {
            cachedValue = (RawValue + addedModifiersValue) * multipliedModifiersValue;
        }
        private void PerformMultiplyOperation(float modifierValue)
        {
            multipliedModifiersValue += modifierValue;
        }

        private void PerformAddOperation(float modifierValue)
        {
            addedModifiersValue += modifierValue;
        }
        

        public void AddModificator(Modifier modifier)
        {
            modifiers.Add(modifier);
            Recalculate(modifier);
        }

        public void RemoveModificator(Modifier modifier)
        {
            if (modifiers.Contains(modifier))
            {
                modifiers.Remove(modifier);
                Recalculate(modifier);
            }
        }
    }
    public class Modifier
    {
        public float value;
        public Operation operation;
        public enum Operation
        {
            Multiply,
            Add
        }
    }
}