# #################### Jadyn Wu ##################
# Thank you for downloading Jadyn Wu's Program
# I hope you find them useful in your projects
# If you have any questions, find my contact in
# my personal website below
# Cheers!
#                   JadynWu.com
# --------------------------------------------------
# Personal Website: https://jadynwu.com/
# GitHub: https://github.com/YuudachiXMMY
# ################################################
import os, logging
import numpy as np
import pandas as pd
import csv

logging.basicConfig(filename="logs.log", filemode="w", level=logging.DEBUG)

info = """
#################### Jadyn Wu ##################
Thank you for downloading Jadyn Wu's Program
I hope you find them useful in your projects
If you have any questions, find my contact in
my personal website below
Cheers!
                  JadynWu.com
--------------------------------------------------
Personal Website: https://jadynwu.com/
GitHub: https://github.com/YuudachiXMMY
################################################
             """
print(info)
logging.info(info)

directory = os.path.abspath(os.path.join(os.path.curdir))

print("Current Working Directory: " + directory)
logging.info("Current Working Directory: " + directory)

#check if dir exist if not create it
def check_dir(file_name):
    directory = os.path.dirname(file_name)
    if not os.path.exists(directory):
        os.makedirs(directory)
    print(directory)

def column_index(df, query_cols):
    cols = df.columns.values
    sidx = np.argsort(cols)
    return sidx[np.searchsorted(cols,query_cols,sorter=sidx)]

def transformToGameData():
    output_file = directory+'//vehicleGroupData.csv'
    check_dir(output_file)
    with open(output_file, 'w', newline='') as file:
        writer = csv.writer(file)

        writer.writerow(["SN", "Movie", "Protagonist"])

car_color_dict = {
    "green" : 0,
    "orange" : 0,
    "black" : 1,
    "red" : 2,
    "blue" : 3,
    "white" : 4
}

def addFunctionToData(row):
    res = ''
    if row["facial_tag"]:
        res += 'facerecog/'
    if row["glasses_tag"]:
        res += 'glasses/'
    if row["language_tag"]:
        res += 'language/'
    if row["pwd_tag"]:
        res += 'password/'
    if row["distance_tag"]:
        res += 'distance/'
    if row["male_tag"]:
        res += 'male/'
    return res.strip("/")

def parseData(file_name="input.csv"):
    try:
        print("Trying to Read file: " + file_name)
        if file_name.endswith('.csv'):
            input_df = pd.read_csv(file_name)
        else:
            input_df = pd.read_excel(file_name)
        print("Success!")
        logging.info("Success!")
    except:
        print("Cannot Read file: " + file_name)
        logging.info("Cannot Read file: " + file_name)

        try:
            print("Try reading input.csv")
            logging.info("Try reading input.csv")
            input_df = pd.read_csv("input.csv")
            print("Success!")
            logging.info("Success!")
        except Exception as e:
            logging.error('Error at %s', 'division', exc_info=e)


    print("Parsing the file...")
    logging.info("Parsing the file...")

    input_df["name_length"] = input_df.iloc[:,6].apply(lambda x: len(x))

    # Cleaning for Data Analysis
    input_df["avg_facial"] = input_df.iloc[:,10].mean()

    input_df["avg_glasses"] = input_df.iloc[:,11].mean()

    input_df["avg_language"] = input_df.iloc[:,12].mean()

    input_df["avg_pwd"] = input_df.iloc[:,14].mean()

    input_df["avg_distance"] = input_df.iloc[:,15].mean()

    input_df["avg_nameLength"] = input_df["name_length"].mean()

    # Analysis DF
    avg_df = input_df[["avg_nameLength", "avg_facial", "avg_glasses", "avg_language", "avg_pwd", "avg_distance"]]

    avg_df = avg_df.round(0)

    # Cleaning for Game df
    input_df["facial_tag"] = input_df["avg_facial"] <= input_df.iloc[:,10]

    input_df["glasses_tag"] = input_df["avg_glasses"] <= input_df.iloc[:,11]

    input_df["language_tag"] = input_df["avg_language"]  <= input_df.iloc[:,12]

    input_df["pwd_tag"] = input_df["avg_pwd"] >= input_df.iloc[:,14]

    input_df["distance_tag"] = input_df["avg_distance"] <= input_df.iloc[:,15]

    input_df["male_tag"] = input_df.iloc[:,13].apply(lambda x: True if x>2 else False)

    input_df['functions'] = input_df.apply(addFunctionToData, axis=1)

    # Game df
    df = input_df.iloc[:, [6,7, column_index(input_df, ['functions'])[0]]]
    df.columns = ['name', 'vehicle', 'functions']

    df.iloc[:,1] = df.iloc[:,1].apply(lambda x: car_color_dict[x.lower()])

    return df, avg_df

def readInput():
    res = input("""
                Please enter your file name
                press enter directly to read input.csv
                (e.g. input.csv , Class1.xlsx)
                """)
    if res == "":
        res = "input.csv"
    return res

try:
    res = readInput()
    df, avg_df = parseData(res)
    print("Success!")
    logging.info("Success!")

    try:
        print("Saving vehicleGroupData.csv file...")
        logging.info("Saving vehicleGroupData.csv file...")
        df.to_csv('vehicleGroupData.csv', sep=',', encoding='utf-8', index=False, header=False)
        print("Success!")
        logging.info("Success!")
    except Exception as e:
        logging.error('Error at %s', 'division', exc_info=e)

    try:
        print("Saving AvgAnalysis.csv file...")
        logging.info("Saving AvgAnalysis.csv file...")
        avg_df.iloc[0:1,:].to_csv('AvgAnalysis.csv', sep=',', encoding='utf-8', index=False, header=True)
        print("Success!")
        logging.info("Success!")
    except Exception as e:
        logging.error('Error at %s', 'division', exc_info=e)

except Exception as e:
    logging.error('Error at %s', 'division', exc_info=e)