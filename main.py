import musicScore
import sys

def main():
    title = sys.argv[1]
    musicFile = sys.argv[2]
    musicScore.musicScore(title, musicFile)  
    

if __name__ == '__main__':
    main()


