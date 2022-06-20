using System;
using System.Collections.Generic;
public class Timer {
    private class Job {
        public float timer;
        public Action action;

        public Job(float time, Action action) {
            this.timer = time;
            this.action = action;
        }
    }
    
    private static Timer _instacne;
    public static Timer Get() {
        if (_instacne == null)
            _instacne = new Timer();

        return _instacne;
    }

    private List<Job> _toRemove = new List<Job>();
    private List<Job> _jobList = new List<Job>();

    public void Update(float dt) {
        foreach (var job in _jobList) {
            job.timer -= dt;

            if (job.timer < 0f) {
                job.action();
                _toRemove.Add(job);   
            }
        }

        if (_toRemove.Count > 0) {
            _jobList.RemoveAll(item => _toRemove.Contains(item));
            _toRemove.Clear();
        }
    }

    public void RegistTimer(float time, Action action) {
        _jobList.Add(new Job(time, action));
    }
}
