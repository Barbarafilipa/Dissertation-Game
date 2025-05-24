É hora do intervalo e estás no recreio a jogar à bola com o teu amigo. #portrait:narration #animation:Child_happySide #animation:Friend_happyRightSide #audio:narrator_lvl6_01

Mas ele empurra-te e fica com a bola. #show:Timeline #animation:Child_serious #animation:Ball_idleFriend #audio:narrator_lvl6_02

Começas a sentir o corpo a aquecer... #hide:Timeline #animation:Child_angry #audio:narrator_lvl6_03

-> minigame_puzzle_raiva

=== continue1 ===
Parabéns, reconheceste a raiva! A raiva aparece quando sentimos que fomos tratados de forma injusta ou quando não conseguimos fazer o que queremos. #portrait:narration #sticker:Raiva #show:Raiva #audio:narrator_lvl6_04

-> main

=== main ===
Isto não é justo! #portrait:thought_lvl6 #animation:Child_angry #animation:Friend_serious #hide:Raiva #audio:child_lvl6_01

+ [Vou empurrá-lo também! $audio:child_lvl6_02]

    Vou empurrá-lo também! #portrait:speech_left_lvl6 #animation:Child_veryAngry #audio:child_lvl6_02
    
    Empurrar de volta só te vai deixar com mais raiva. Magoar os outros não resolve o problema e pode deixar os dois tristes. #portrait:narration #audio:narrator_lvl6_05
    
    O teu amigo pode ficar ainda mais chateado. Vamos tentar resolver isto de outra forma? #audio:narrator_lvl6_06
    
    -> main
    
+ [Vou brincar com outro amigo. $audio:child_lvl6_03]

    Vou brincar com outro amigo. #portrait:speech_left_lvl6 #animation:Child_stubborn #audio:child_lvl6_03
    
    Sair sem dizer nada pode fazer o teu amigo pensar que não queres mais brincar com ele.  #portrait:narration #audio:narrator_lvl6_07
    
    Se explicares como te sentiste pode ser mais fácil resolverem o problema juntos. #audio:narrator_lvl6_08
    
    -> main
    
+ [Se calhar foi sem querer. $audio:child_lvl6_04]

    Se calhar foi sem querer. #portrait:speech_left_lvl6 #animation:Child_seriousSide #audio:child_lvl6_04
    
    Às vezes as coisas acontecem sem intenção. Pensar assim ajuda-te a acalmar e a resolver melhor o problema. Agora tenta falar com ele com calma. #portrait:narration #animation:Child_smiling #audio:narrator_lvl6_09
    
    -> minigame_reciclagem_da_raiva
    

=== continue2 ===
Parabéns! Aprendeste que, tal como reciclamos o lixo, também podemos reciclar os pensamentos maus e transformar a raiva em algo melhor. #portrait:narration #animation:Child_veryHappy #sticker:ReciclagemDaRaiva #show:ReciclagemDaRaiva #audio:narrator_lvl6_10

Já me sinto melhor. Vou falar com ele. #portrait:speech_left_lvl6 #animation:Child_smiling #hide:ReciclagemDaRaiva #audio:child_lvl6_05

Ei! #portrait:speech_left_lvl6 #animation:Child_happy #audio:child_lvl6_06
... #portrait:speech_right_lvl6_friend #animation:Friend_seriousSide #animation:Child_worried

Ele já não quer jogar comigo... #portrait:speech_left_lvl6 #animation:Child_worried #animation:Friend_seriousSide #audio:child_lvl6_07

Às vezes as coisas não acontecem como esperávamos, e isso pode fazer-nos sentir tristes. #portrait:narration #audio:narrator_lvl6_11

-> novas_escolhas

=== novas_escolhas ===

E agora? #portrait:thought_lvl6 #audio:child_lvl6_08

+ [Ele já não gosta de mim, é por isso que não quer jogar comigo... $audio:child_lvl6_09]
    
    Ele já não gosta de mim, é por isso que não quer jogar comigo... #portrait:speech_left_lvl6 #audio:child_lvl6_09
    
    Quando estamos tristes, a nossa cabeça fica a girar só nos mesmos pensamentos. Mas pensar só nas coisas tristes não nos ajuda a entender o que aconteceu. Vamos tentar parar essa roda? #portrait:narration #audio:narrator_lvl6_12

    -> novas_escolhas

+ [Nunca mais quero falar com ele! $audio:child_lvl6_10]

    Nunca mais quero falar com ele! #portrait:speech_left_lvl6 #animation:Child_stubborn #audio:child_lvl6_10
    
    Quando estamos tristes, às vezes queremos fugir ou ir embora. Mas isso é como esconder a tristeza debaixo do tapete. #portrait:narration #audio:narrator_lvl6_13
    
    Pode parecer que está tudo bem, mas o problema não desaparece. Que tal falar com ele sobre como te sentes? #audio:narrator_lvl6_14

    -> novas_escolhas
    
+ [Vou-lhe dizer que fiquei magoado. $audio:child_lvl6_11]

    Vou-lhe dizer que fiquei magoado. #portrait:speech_left_lvl6 #audio:child_lvl6_11
    
    Falar sobre os sentimentos é uma boa maneira de resolver os problemas. Às vezes os nossos amigos não sabem como nos sentimos. #portrait:narration #animation:Child_smiling #audio:narrator_lvl6_15

    -> minigame_reconstruir_amizade
    
=== continue3 ===

Parabéns! Conseguiste reparar a amizade com o teu amigo. Quando ficamos tristes às vezes é difícil falar, mas soubeste expressar os teus sentimentos e ultrapassaste o momento difícil. #portrait:narration #animation:Child_veryHappy #animation:Friend_smiling #sticker:MuroDaAmizade #show:MuroDaAmizade #audio:narrator_lvl6_16

Ei, eu fiquei triste porque não quiseste jogar comigo. #portrait:speech_left_lvl6 #animation:Child_smilingSide #hide:MuroDaAmizade #audio:child_lvl6_12

Está tudo bem, mas queria que soubesses. #audio:child_lvl6_13

Desculpa, não queria magoar-te. #portrait:speech_right_lvl6_friend #audio:friend_lvl6_01

Se quiseres podemos jogar juntos agora. #audio:friend_lvl6_02

Com a raiva, aprendeste a pensar antes de agir, e com a tristeza, partilhaste o que sentias. Uma conversa honesta ajudou a resolver tudo e a tornar a amizade mais forte! #portrait:narration #animation:Child_veryHappy #animation:Friend_veryHappy #sticker:ConversaHonesta #show:ConversaHonesta #audio:narrator_lvl6_17

-> END

=== minigame_puzzle_raiva ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleRaiva
-> continue1

=== minigame_reciclagem_da_raiva ===
Minijogo Reciclagem da Raiva #minigame:ReciclagemdaRaiva
-> continue2

=== minigame_reconstruir_amizade ===
Minijogo Reconstruir a Amizade #minigame:ReconstruirAmizade
-> continue3
