import librosa
import soundfile as sf
import numpy as np

def computeBeatsRmsChroma(musicFile):
    # ファイル読み込み
    y, sr = librosa.load(musicFile)    
    # y, sr = librosa.load(librosa.ex('trumpet'))
    temp, beats = librosa.beat.beat_track(y=y, sr=sr)
    # RMS
    rms = librosa.feature.rms(y=y)
    #クロマグラム
    chroma = librosa.feature.chroma_stft(y=y, sr=sr)
    frame = chroma.shape[1]
    # print(chroma)
    #各フレームのクロマグラムが一番強いものを求める
    # 0:'C',1:'Db',2:'D',3:'Eb',4:'E',5:'F',6:'Gb',7:'G',8:'Ab',9:'A',10:'Bb',11:'B'
    notesChromaList=[]
    for i in range(frame):
        
        for j in range(12):
            a=chroma[j,i]
            if a==1.0:
                notesChromaList.append(j)
                break;
    # beatsだけを取り出す
    beatsChroma = []
    for b in beats:
        beatsChroma.append(notesChromaList[b-1])
    # print(beatsChroma)
    
    beatsRms = []
    for b in beats:
        beatsRms.append(rms[0][b-1])
    sortedList = sorted(beatsRms, reverse=True)

    beatsSet = []
    for b in range(len(beats)):
        beatsSet.append([beats[b], beatsRms[b], beatsChroma[b]])
    # print(beatsSet)

    return beatsSet, frame