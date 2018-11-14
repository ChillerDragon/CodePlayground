section .data
    msg db 0x0a, 0x0a, "hello world", 0x0a, 0x0a, 0x0a
    len equ $-msg
section .text
global start
start
    mov eax, 4
    push dword len
    push dword msg
    push dword 1
    push dword eax
    int 0x80
    add esp, 16

    mov eax, 1
    push dword 0
    push dword eax
    int 0x80
