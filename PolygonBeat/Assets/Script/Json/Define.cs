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
        public List<BeatData> beatData;
        public List<Data> data;
    }

    [System.Serializable]
    public class BeatData
    {
        public float touchTime;
    }
    [System.Serializable]
    public class Data
    {
        public int index;
        public float bpm;
        public int count;
    }
    [System.Serializable]
    public class UserCharacterData
    {
        public List<IndividualCharacter> individualCharacters;
    }
    [System.Serializable]
    public class IndividualCharacter
    {
        private int _rarity;
        private int _characterIndex;
        private bool _isHave;
        private int _shape;

        public int Rarity
        {
            get { return _rarity; }
            set { _rarity = value; }
        }
        public int CharacterIndex
        {
            get { return _characterIndex; }
            set { _characterIndex = value; }
        }

        public int Shape
        {
            get { return _shape; }
            set { _shape = value; }
        }
        public bool IsHave
        {
            get { return _isHave; }
            set { _isHave = value; }
        }

        public IndividualCharacter(int characterIndex, bool isHave, int rarity, int shape)
        {
            this._characterIndex = characterIndex;
            this._isHave = isHave;
            this._rarity = rarity;
            this._shape = shape;
        }
    }

    [System.Serializable]
    public class WholeGameData
    {
        public bool _tutorialClear;
        public int _coin;
        public int _currentSong;
        public float _masterVolume;
        public float _bgmVolume;
        public float _sfxVolume;

        public WholeGameData(bool tutorialClear, int coin, float masterVolume, float bgmVolume, float sfxVolume, int currentSong)
        {
            this._tutorialClear = tutorialClear;
            this._coin = coin;
            this._masterVolume = masterVolume;
            this._bgmVolume = bgmVolume;
            this._sfxVolume = sfxVolume;
            this._currentSong = currentSong;
        }
    }
    [System.Serializable]
    public class SaveData
    {
        public int savePoint;
        public float saveMusicTime;
    }
}
