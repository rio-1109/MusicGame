import librosa
import json
import numpy
import math
import uselibrosa
import returnJson
import notes as n
import io

def musicScore(title, musicFile):
    beatsSet, frame = uselibrosa.computeBeatsRmsChroma(musicFile)

    score = returnJson.scoreJson()
    notes = n.Notes(score,beatsSet, frame)

    notes.longDoubleNotes()
    notes.longSingleNotes()
    
    notes.doubleNotes()
    notes.singleNotes()
    
    
    score.write_json(title)   

