from flask import Flask, request, jsonify
import pandas as pd

app = Flask(__name__)

@app.route('/process_csv', methods=['POST'])
def process_csv():
    file = request.files['csv_file']
    df = pd.read_csv(file)
    
    
    
    result = df.to_json(orient='records')
    return jsonify(result)

if __name__ == '__main__':
    app.run(debug=True)