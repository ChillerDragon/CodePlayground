#!/usr/bin/env python2

import os
import os.path

def init_res_file():
    global res_folder
    res_folder = raw_input("ressource folder: ")
    
    if not res_folder:
        print("using default...")
        res_folder = "default"
    
    
    
    if not os.path.isdir('res/' + res_folder):
        print("'/res/" + res_folder + "' not found --> creating it...")
        os.makedirs('res/' + res_folder)
        files_init = open('res/' + res_folder + '/stuff.txt', 'w')
        files_init.write("x" + "\n")
        files_init.write("X" + "\n")
        files_init.write("xx" + "\n")
        files_init.write("XX" + "\n")
        files_init.write("xX" + "\n")
        files_init.write("Xx" + "\n")
        files_init.write("-" + "\n")
        files_init.write("--" + "\n")
        files_init.write("_" + "\n")
        files_init.write("__" + "\n")
        files_init.write("iam" + "\n")
        files_init.write("Iam" + "\n")
        files_init.write("iAM" + "\n")
        files_init.write("IAm" + "\n")
        files_init.write("IAM" + "\n")
        files_init.write("UR" + "\n")
        files_init.write("ur" + "\n")
        files_init.write("your" + "\n")
        files_init.write("YOUR" + "\n")
        files_init.write("you_are" + "\n")
        files_init.write("you_are_" + "\n")
        files_init.write("YOU_ARE" + "\n")
        files_init.write("YOU_ARE_" + "\n")
        files_init.write("YouR" + "\n")
        files_init.write("u_r" + "\n")
        files_init.write("YouAre" + "\n")
        files_init.write("YOUARE" + "\n")
        files_init.write("y0uar3" + "\n")
        files_init.write("Y0UAr3" + "\n")
        files_init.write("Ich" + "\n")
        files_init.write("ich" + "\n")
        files_init.write("IchLiebe" + "\n")
        files_init.write("ichliebe" + "\n")
        files_init.write("Ilove" + "\n")
        files_init.write("ilove" + "\n")
        files_init.write("iLove" + "\n")
        files_init.write("you" + "\n")
        files_init.write("u" + "\n")
        files_init.write("YOU" + "\n")
        files_init.write("Y0U" + "\n")
        files_init.write("frieden" + "\n")
        files_init.write("FRIEDEN" + "\n")
        files_init.write("blume" + "\n")
        files_init.write("blau" + "\n")
        files_init.write("rot" + "\n")
        files_init.write("grün" + "\n")
        files_init.write("gelb" + "\n")
        files_init.write("orange" + "\n")
        files_init.write("gelb" + "\n")
        files_init.write("rot" + "\n")
        files_init.write("lila" + "\n")
        files_init.write("Katzen" + "\n")
        files_init.write("katzen" + "\n")
        files_init.write("red" + "\n")
        files_init.write("rabbit" + "\n")
        files_init.close()
        files_init = open('res/' + res_folder + '/names.txt', 'w')
        files_init.write("robert" + "\n")
        files_init.write("Robert" + "\n")
        files_init.write("jessica" + "\n")
        files_init.write("Jessica" + "\n")
        files_init.write("anna" + "\n")
        files_init.write("Anna" + "\n")
        files_init.write("caty" + "\n")
        files_init.write("Caty" + "\n")
        files_init.write("Fritz" + "\n")
        files_init.write("fritz" + "\n")
        files_init.write("Peter" + "\n")
        files_init.write("peter" + "\n")
        files_init.write("" + "\n")
        files_init.close()
    else:
        print("loading ressources...")



def load_resources():
    if os.path.isfile('res/' + res_folder + '/stuff.txt'):
        global aStuff
        fStuff = open('res/' + res_folder + '/stuff.txt', 'r')
        aStuff = fStuff.read().splitlines()
        print("Loading 'res/" + res_folder + "/stuff.txt'")
    else:
        print("Error loading 'res/" + res_folder + "/stuff.txt'.")
        exit()

    if os.path.isfile('res/' + res_folder + '/names.txt'):
        global aNames
        fNames = open('res/' + res_folder + '/names.txt', 'r')
        aNames = fNames.read().splitlines()
        print("Loading 'res/" + res_folder + "/names.txt'")
    else:
        print("Error loading 'res/" + res_folder + "/names.txt'.")
        exit()

def start_menu():
    print('~~~~~~~~~~~~~~~~~~')
    print('password list generator')
    print('made by ChillerDragon')
    print('choose mode bewteen:')
    print('password')
    print('names')
    print('stuff')
    print('vanilla')
    print('~~~~~~~~~~~~~~~~~~')
    global file_name
    global mode
    mode = raw_input('_ ')
    if mode == "password":
        load_resources()
        file_name = raw_input("file: ")
        if not os.path.isfile(file_name):
            init_password_file()
        else:
            print("File loaded...")
        add_passwords_user_inp()
    elif mode == "names":
        file_name = 'res/' + res_folder + '/names.txt'
        add_names_user_inp()
    elif mode == "stuff":
        file_name = 'res/' + res_folder + '/stuff.txt'
        add_stuff_user_inp()
    elif mode == "vanilla":
        file_name = raw_input("file: ")
        add_vanilla_user_inp()
    else:
        print("mode not found.")
        start_menu()

def init_password_file():
    print("File not found...")
    print("Creating new file ...")
    print("")
    for x in aStuff:
        append_passwords_main(x)
    for x in aNames:
        append_passwords_main(x)

def add_stuff(password):
    for word in aStuff:
        wPass.write(word + password + "\n") #double on init
        add_numbers(word + password, 101)
        wPass.write(word + password + word + "\n") #tripple on init
        add_numbers(word + password + word, 101)
        if not word == password: #only double stuff init once
            wPass.write(password + word + "\n")
            add_numbers(password + word, 101)

def add_numbers(password, amount = 2100): #2100
    for i in range(0, amount):
        wPass.write(password + str(i) + "\n")
        wPass.write(str(i) + password + "\n")
    for i in range(0, 10):
        wPass.write(password + "0" + str(i) + "\n")
        wPass.write("0" + str(i) + password + "\n")
    for i in range(0, 100):
        wPass.write(password + "00" + str(i) + "\n")
        wPass.write("00" + str(i) + password + "\n")

def check_double(password):
    global upper_password
    global lower_password
    global lower_password
    global title_password
    global E3_password
    global upperE3_password
    raw_password = password
    raw_password = raw_password.replace(' ','_')
    upper_password = raw_password.upper()
    lower_password = raw_password.lower()
    title_password = raw_password.title()
    E3_password = raw_password.replace('E','3')
    E3_password = raw_password.replace('e','3')
    upperE3_password = upper_password.replace('E','3')
    with open(file_name, "r") as ins:
        for line in ins:
            if line == raw_password + "\n":
                return -1
            elif line == upper_password + "\n":
                return 1
    return 0

def append_passwords_main(password):
    global wPass
    wPass = open(file_name, "a")
    similar_found = False
    raw_password = password

    check_double_value = check_double(raw_password)
    if check_double_value == -1:
        print("ERROR password '" + raw_password + "' found.")
    elif check_double_value == 0:
        print("adding '" + raw_password + "' ...")
    elif check_double_value == 1:
        print("WARNING similar password found.")
        similar_found = True
    else:
        print("WARNING unknown error")

    if not check_double_value == -1:
        wPass.write(raw_password + "\n")
        add_stuff(raw_password)
        add_numbers(raw_password)
        if not E3_password == raw_password:
            wPass.write(E3_password + "\n")
            add_numbers(E3_password)
        if not check_double_value == 1:
            if not lower_password == raw_password:
                wPass.write(lower_password + "\n")
                add_numbers(lower_password)
            if not upper_password == raw_password:
                wPass.write(upper_password + "\n")
                add_numbers(upper_password)
            if not title_password == raw_password:
                wPass.write(title_password + "\n")
                add_numbers(title_password)
            if not upperE3_password == upper_password:
                wPass.write(upperE3_password + "\n")
                add_numbers(upperE3_password)

    wPass.close()


def append_names_main(name):
    global wNames
    wNames = open(file_name, 'a')
    raw_name = name
    lower_name = raw_name.lower()
    title_name = raw_name.title()
    check_double_value = 0
    with open(file_name, 'r') as ins:
        for line in ins:
            if line == lower_name + "\n":
                check_double_value = -1
    with open('res/' + res_folder + '/stuff.txt', 'r') as ins:
        for line in ins:
            if line == lower_name + "\n" or line == title_name + "\n":
                check_double_value = 1

    if check_double_value == 0:
        print("adding '" + raw_name + "' ...")
    elif check_double_value == 1:
        print("WARNING name '" + raw_name + "' in res/stuff.txt found.")
    elif check_double_value == -1:
        print("ERROR name '" + raw_name + "' found.")
    else:
        print("WARNING unknow error.")

    if not check_double_value == -1:
        wNames.write(lower_name + "\n")
        wNames.write(title_name + "\n")
        wNames.close()

def append_vanilla_main(vanilla):
    global wVanilla
    wVanilla = open(file_name, 'a')
    lower_vanilla = vanilla.lower()
    upper_vanilla = vanilla.upper()
    check_double_value = 0
    with open(file_name, 'r') as ins:
        for line in ins:
            if line == vanilla + "\n":
                check_double_value = -1
            elif line == lower_vanilla + "\n":
                check_double_value = 1
            elif line == upper_vanilla + "\n":
                check_double_value = 2

    if check_double_value == -1:
        print("ERROR found the word '" + vanilla + "' in file.")
    elif check_double_value == 0:
        print("adding '" + vanilla + "' ...")
    elif check_double_value == 1:
        print("WARNING found '" + lower_vanilla + "' in file.")
    elif check_double_value == 2:
        print("WARNING found '" + upper_vanilla + "' in file.")

    if not check_double_value == -1:
        wVanilla.write(vanilla + "\n")
        wVanilla.close()


def append_stuff_main(stuff):
    global wStuff
    wStuff = open(file_name, 'a')
    raw_stuff = stuff
    check_double_value = 0
    with open(file_name, 'r') as ins:
        for line in ins:
            if line == raw_stuff + "\n":
                check_double_value = -1
    with open('res/' + res_folder + '/names.txt', 'r') as ins:
        for line in ins:
            if line == raw_stuff + "\n":
                check_double_value = 1

    if check_double_value == 0:
        print("adding '" + raw_stuff + "' ...")
    elif check_double_value == 1:
        print("WARNING name '" + raw_stuff + "' in res/names.txt found.")
    elif check_double_value == -1:
        print("ERROR name '" + raw_stuff + "' found.")
    else:
        print("WARNING unknow error.")

    if not check_double_value == -1:
        wStuff.write(raw_stuff + "\n")
        wStuff.close()

def add_stuff_user_inp():
    IsError = False
    inp_stuff = raw_input(mode + "_ ")
    append_stuff_main(inp_stuff)
    add_stuff_user_inp()

def add_names_user_inp():
    IsError = False
    inp_name = raw_input(mode + "_ ")
    append_names_main(inp_name)
    add_names_user_inp()

def add_passwords_user_inp():
    IsError = False
    inp_password = raw_input(mode + "_ ")
    with open('res/' + res_folder + '/stuff.txt', 'r') as ins:
        for line in ins:
            if line == inp_password + "\n":
                print("ERROR password '" + inp_password + "' found in stuff.")
                IsError = True
    if not IsError:
        append_passwords_main(inp_password)
    add_passwords_user_inp()

def add_vanilla_user_inp():
    inp_vanilla = raw_input(mode + "_ ")
    append_vanilla_main(inp_vanilla)
    add_vanilla_user_inp()

init_res_file()
start_menu()







