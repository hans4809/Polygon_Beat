using System;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    [System.Serializable]
    public class MusicData
    {
        public List<Music> music;
    }
    [System.Serializable]
    public class Music
    {
        public List<Data> data;
    }

    [System.Serializable]
    public class Data
    {
        public int index;
        public int bpm;
        public int count;
    }
    //public List<MusicData> _musicList = new List<MusicData>();
    
    /*  [System.Serializable]public class MusicData
    {
        public int Index { get; set; }
        public int Bpm { get; set; }
        public int Count { get; set; }

        public MusicData(int index, int bpm, int count) 
        {
            Index = index;
            Bpm = bpm;
            Count = count;
        }
        public class Root
        {
            public List<MusicData> music5 { get; set; }
        }
    }*/


    public class CharacterData
    {
        private int _characterIndex;
        private bool _isHave;

        public int CharacterIndex
        {
            get { return _characterIndex; }
            set { _characterIndex = value; }
        }

        public bool IsHave
        {
            get { return _isHave; }
            set { _isHave = value; }
        }

        public CharacterData(int characterIndex, bool isHave)
        {
            this._characterIndex = characterIndex;
            this._isHave = isHave;
        }
    }

    public class WholeGameData
    {
        private bool _tutorialClear;
        private int _coin;
        public float _masterVolume;
        public float _bgmVolume;
        public float _sfxVolume;

        public bool TutorialClear
        {
            get { return _tutorialClear; }
            set { _tutorialClear = value; }
        }

        public int Coin
        {
            get { return _coin; }
            set { _coin = value; }
        }

        public WholeGameData(bool tutorialClear, int coin, float masterVolume, float bgmVolume, float sfxVolume)
        {
            this._tutorialClear = tutorialClear;
            this._coin = coin;
            this._masterVolume = masterVolume;
            this._bgmVolume = bgmVolume;
            this._sfxVolume = sfxVolume;
        }
    }
}
