import musicScore
import random
import returnJson
import numpy as np

class Notes:
    
    def __init__ (self, score,beatsSet, frame):
        self.score = score
        self.beatsSet = beatsSet
        self.frame = frame

    def longDoubleNotes(self):
        longDoubleNotesSet = []
        longDoubleNotesList = []
        longDoubleNotesLane = []

        longDoubleNotes_n = int(len(self.beatsSet)*0.1)

        if((longDoubleNotes_n%2) != 0) :
            longDoubleNotes_n+=1
        sortedBeatsSet = self.sortBeatsSetRMS(self.beatsSet)
        
        for i in range(len(self.beatsSet)):
            if(self.beatsSet[i][1] > sortedBeatsSet[longDoubleNotes_n][1]):
                    longDoubleNotesList.append(self.beatsSet[i])
        
        longDoubleNotesSet = self.longNotes(longDoubleNotesList)

        longDoubleNotesLane = self.setLongNotesLane(longDoubleNotesSet)
        
        self.score.setlongDoubleNotes(longDoubleNotesSet,longDoubleNotesLane)

        self.deleteUseBeatsSetLong(longDoubleNotesSet)


    def longSingleNotes(self):
        longSingleNotesSet = []
        longSingleNotesList = []
        longSingleNotesLane = []

        longSingleNotes_n = int(len(self.beatsSet)*0.1)

        if((longSingleNotes_n%2) != 0) :
            longSingleNotes_n+=1
        sortedBeatsSet = self.sortBeatsSetRMS(self.beatsSet)
        for i in range(len(self.beatsSet)):
            if(self.beatsSet[i][1] > sortedBeatsSet[longSingleNotes_n][1]):
                    longSingleNotesList.append(self.beatsSet[i])
        
        longSingleNotesSet = self.longNotes(longSingleNotesList)
        
        longSingleNotesLane = self.setLongNotesLane(longSingleNotesSet)
        
        # jsonに書き出す
        self.score.setLongSingleNotes(longSingleNotesSet, longSingleNotesLane)
        # 使ったタイミングは消す
        self.deleteUseBeatsSetLong(longSingleNotesSet)

    # 長押しをつなげてセットにする
    def longNotes(self, list):
        set = []
        # even = np.empty(int(len(list)/2))
        # odd = np.empty(int(len(list)/2))
        even = []
        odd = []
        check = int(self.frame*0.15)
        
        for i in range(len(list)):
            if i%2 != 0:
                odd.append(list[i])
                # print('odd',odd)
            else:
                even.append(list[i])
                # print('even', even)
            
        for i in range(len(even)):
            # フレームがcheckだけ離れていたらスキップする
            if ((odd[i][0]-even[i][0]) > check):
                break;
            else:
                set.append([even[i], odd[i]])
        
        return set
        
    # beatsSetを並び替える(RMSの大きい順に)
    def sortBeatsSetRMS(self, list):
        list = sorted(list, reverse=True, key=lambda x:x[1])
        return list

    # 長押しのレーンを決める
    def setLongNotesLane(self, list):
        laneList = []
        for i in range(len(list)):
            c = list[i][0][2]
            if (c < 2):
                laneList.append(1)
            elif (c < 5):
                laneList.append(2)
            elif (c < 7):
                laneList.append(3)
            elif (c < 10):
                laneList.append(4)
            else:
                laneList.append(5)
        return laneList

    # キーボード一つだけ押す　（残っているやつ全部）
    def singleNotes(self):
        singleNotesList = []
        singleNotesLane = []
        for i in range(len(self.beatsSet)):
            singleNotesList.append(self.beatsSet[i])
        singleNotesLane = self.setNotesLane(singleNotesList)
        # jsonに書き出す
        self.score.setSingleNotes(singleNotesList, singleNotesLane)
        # 使ったタイミングは消す
        self.deleteUseBeatsSetTap(singleNotesList)
    
    # キーボード同時押し
    def doubleNotes(self):
        doubleNotesList = []
        doubleNotesLane = []

        doubleNotesList_n = int(len(self.beatsSet)*0.1)

        sortedBeatsSet = self.sortBeatsSetRMS(self.beatsSet)

        for i in range(len(self.beatsSet)):
            if(self.beatsSet[i][1] > sortedBeatsSet[doubleNotesList_n][1]):
                    doubleNotesList.append(self.beatsSet[i])

        doubleNotesLane = self.setNotesLane(doubleNotesList)

        self.score.setDoubleNotes(doubleNotesList, doubleNotesLane)
        self.deleteUseBeatsSetTap(doubleNotesList)

    # 一つだけキーボード押しのレーンを決める
    def setNotesLane(self, list):
        laneList = []
     
        for i in range(len(list)):
            laneList.append(self.setLane(list[i][2]))
        return laneList
    
    # レーンを決める（場合分け）
    def setLane(self, c):
        if (c < 2):
            return 1
        elif (c < 5):
            return 2
        elif (c < 7):
            return 3
        elif (c < 10):
            return 4
        else:
            return 5

    # 長押し使ったやつ消す
    def deleteUseBeatsSetLong(self, list):
        for i in range(len(list)):
            indexStart = self.beatsSet.index(list[i][0])
            indexEnd = self.beatsSet.index(list[i][1])
            del self.beatsSet[indexStart:indexEnd+1]


    def deleteUseBeatsSetTap(self, list):
        for i in range(len(list)):
            index = self.beatsSet.index(list[i])
            del self.beatsSet[index]
        
        
    
    # -----------------------------------------------


    