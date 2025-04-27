É hora de dormir, mas sentes um frio na barriga ao apagar as luzes. #portrait:narration
O quarto parece cheio de sombras estranhas e barulhos esquisitos…

-> minigame_puzzle_medo

=== continue1 ===
Parabéns, reconheceste o medo! O medo aparece quando achamos que algo nos pode fazer mal, mesmo que não seja de verdade. #portrait:narration

Está tudo bem? #portrait:speech_right #speaker:Mother

-> main

=== main ===
E se tiver um monstro no meu quarto? #portrait:thought

+ [Não quero apagar a luz, posso dormir com ela acesa?]
    Não quero apagar a luz, posso dormir com ela acesa? #portrait:speech_left
    Tens a certeza? #portrait:speech_right
    -> main
+ [E se ele estiver escondido e só sair quando eu fechar os olhos?]
    E se ele estiver escondido e só sair quando eu fechar os olhos? #portrait:speech_left
    Assim não vais conseguir dormir. #portrait:speech_right
    -> main
    
+ [Estou com medo, mas sei que é a minha imaginação.]
    Estou com medo, mas sei que é a minha imaginação. #portrait:speech_left
    Vamos ver o que é. #portrait:speech_right
    -> minigame_lanterna_da_coragem

=== continue2 ===
Se voltares a sentir medo, já sabes: podes olhar à tua volta e lembrar-te que muitas vezes o medo vem da nossa cabeça. #portrait:speech_right

-> END

=== minigame_puzzle_medo ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleMedo
-> continue1

=== minigame_lanterna_da_coragem ===
#minigame:LanternaDaCoragem
-> continue2
