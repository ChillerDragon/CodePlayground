#!/usr/bin/env python2

import argparse, os, time
import urlparse, random
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
import BeautifulSoup

def Main():
    browser = webdriver.Firefox()
    browser.get("https://www.facebook.com/login/")



Main()
