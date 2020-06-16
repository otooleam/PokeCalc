import json

def getNum(key):
    return int(key[:3])

with open('BBJson\pokemon_list.json') as file:
    dictionary = json.load(file)

with open('Pokedex.json', 'w') as pokedex:
    key = dictionary.keys()
    pokedex.write('[\n')
    for pokemon in key:
        pokedex.write('\t{\n')
        pokedex.write('\t\t\"name\": \"' + dictionary[pokemon]["name"] + '\",\n')
        pokedex.write(f'\t\t\"number\": {getNum(pokemon)},\n')
        pokedex.write(f'\t\t\"hp\": {dictionary[pokemon]["stamina"]},\n')
        pokedex.write(f'\t\t\"attack\": {dictionary[pokemon]["attack"]},\n')
        pokedex.write(f'\t\t\"defense\": {dictionary[pokemon]["defense"]},\n')
        pokedex.write('\t\t\"type\": [\"' + dictionary[pokemon]["types"][0] + '\"')
        if len(dictionary[pokemon]["types"]) == 2:
            pokedex.write(", \"" + dictionary[pokemon]["types"][1] + "\"")
        pokedex.write("]" + "\n")
        pokedex.write("\t}," + "\n")
    pokedex.write("]" + "\n")
    pokedex.close()
