*** Settings ***
Library    SeleniumLibrary

*** Test Cases ***
Case 01
	ไปหน้าแรกของ google
	Input Text   name:q2    data

*** Keywords ***
ไปหน้าแรกของ google
	Open Browser    https://www.google.com   browser=gc

