using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Containment;
using GameSystems;
namespace Units.Modules {
    public class SlaveModule : BehaviourModule
    {
        public List<Crime> crimeHistory = new List<Crime>();
        public LawStatus lawStatus;
        public int Severity
        {
            get => severity;
            set
            {
                severity += value;
                Debug.Log($"{mono.name} severity is {severity}");
                if (severity >= lawStatus.severityCap && lawStatus.Next != null)
                {
                    lawStatus = lawStatus.Next;
                    Debug.Log($"{mono.name} now has {lawStatus.name} law status");
                }
                
            }
        }
        public void CrimeCommitted(Crime crime)
        {
            crimeHistory.Add(crime);
            Severity = crime.severity;
        }
        int severity;
        public SlaveModule(Agent _mono,CrimeCodex codex) : base(_mono)
        {
            lawStatus = codex.GetLawStatus(0);
        }
    }
}