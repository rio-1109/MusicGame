import json

from numpy.lib.index_tricks import diag_indices_from
import librosa
import math

class scoreJson:
    data = dict()
    data['title'] = 'sample'
    notes = []

    def setlongDoubleNotes(self, longDoubleNotesSet, longDoubleNotesLane):
        for i in range(len(longDoubleNotesSet)):
            timeAndLane = dict()
            start = str(math.floor(librosa.frames_to_time(longDoubleNotesSet[i][0][0])*1000))
            end = str(math.floor(librosa.frames_to_time(longDoubleNotesSet[i][1][0])*1000))
            timeAndLane['start'] = start
            timeAndLane['end'] = end
            timeAndLane['lane'] = longDoubleNotesLane[i]
            self.notes.append(timeAndLane)
            #--------
            timeAndLane = dict()
            timeAndLane['start'] = start
            timeAndLane['end'] = end
            if longDoubleNotesLane[i] == 1:
                timeAndLane['lane'] = "5"
            elif longDoubleNotesLane[i] == 2:
                timeAndLane['lane'] = "4"
            elif longDoubleNotesLane[i] == 3:
                break;
            elif longDoubleNotesLane[i] == 4:
                timeAndLane['lane'] = "2"
            else:
                timeAndLane['lane'] = "5"

            self.notes.append(timeAndLane)


    def setLongSingleNotes(self,longSingleNotesSet, longSingleNotesLane):
        for i in range(len(longSingleNotesSet)):
            timeAndLane = dict()
            timeAndLane['start'] = str(math.floor(librosa.frames_to_time(longSingleNotesSet[i][0][0])*1000))
            timeAndLane['end'] = str(math.floor(librosa.frames_to_time(longSingleNotesSet[i][1][0])*1000))
            # timeAndLane['start'] = str(longSingleNotesSet[i][0][0])
            # timeAndLane['end'] = str(longSingleNotesSet[i][1][0])
            timeAndLane['lane'] = str(longSingleNotesLane[i])
            self.notes.append(timeAndLane)
    
    def setSingleNotes(self, SingleNotesList, SingleNotesLane):

        for i in range (len(SingleNotesList)):
            timeAndLane = dict()
            timeAndLane['start'] = str(math.floor(librosa.frames_to_time(SingleNotesList[i][0])*1000))
            timeAndLane['end'] = str(math.floor(librosa.frames_to_time(SingleNotesList[i][0])*1000))
            timeAndLane['lane'] = str(SingleNotesLane[i])
            self.notes.append(timeAndLane)

    def setDoubleNotes(self, doubleNotesList, doubleNotesLane):
        
        for i in range (len(doubleNotesList)):
            timeAndLane = dict()
            start = str(math.floor(librosa.frames_to_time(doubleNotesList[i][0])*1000))
            end = str(math.floor(librosa.frames_to_time(doubleNotesList[i][0])*1000))
            timeAndLane['start'] = start
            timeAndLane['end'] = end
            timeAndLane['lane'] = str(doubleNotesLane[i])
            self.notes.append(timeAndLane)
            #----------------------------------------------------------------
            timeAndLane = dict()
            timeAndLane['start'] = start
            timeAndLane['end'] = end
            lane = self.setLane(doubleNotesLane[i])
            if (lane == 3):
                break;
            timeAndLane['lane'] = str(lane)
            
            self.notes.append(timeAndLane)

    def setLane(self, lane):
        if lane == 1:
            return 5
        elif lane == 2:
            return 4
        elif lane == 3:
            return 3
        elif lane == 4:
            return 2
        else:
            return 1

    def write_json(self, title):
        self.data['title'] = title
        self.data['notes'] = self.notes
        score = json.dumps(self.data)
        with open(title+'.json', 'w') as f:
            json.dump(self.data, f,indent=2, ensure_ascii=False)
        

        