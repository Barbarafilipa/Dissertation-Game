É hora de dormir, mas sentes um frio na barriga ao apagar as luzes. #portrait:narration
O quarto parece cheio de sombras estranhas e barulhos esquisitos…

-> minigame_labirinto

=== minigame_labirinto ===
#minigame:labirinto

Está tudo bem? #portrait:speech_right

-> main

=== main ===
E se tiver um monstro no meu quarto? #portrait:thought

+ [Não quero apagar a luz, posso dormir com ela acesa?]
    Não quero apagar a luz, posso dormir com ela acesa? #portrait:default
    Tens a certeza? #portrait:speech_right
    -> main
+ [E se ele estiver escondido e só sair quando eu fechar os olhos?]
    E se ele estiver escondido e só sair quando eu fechar os olhos? #portrait:default
    Assim não vais conseguir dormir. #portrait:speech_right
    -> main
    
+ [Estou com medo, mas sei que é a minha imaginação.]
    Estou com medo, mas sei que é a minha imaginação. #portrait:speech_left
    Vamos ver o que é. #portrait:speech_right
    
    -> minigame_lanterna

=== continue ===
Se voltares a sentir medo, já sabes: podes olhar à tua volta e lembrar-te que muitas vezes o medo vem da nossa cabeça. #portrait:speech_right

-> END

=== minigame_lanterna ===
#minigame:lanterna
-> continue
