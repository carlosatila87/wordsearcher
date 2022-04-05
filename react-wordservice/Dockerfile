FROM node:alpine3.14
RUN mkdir -p /app
WORKDIR /app
EXPOSE 8081
COPY package*.json ./
RUN npm install --no-optional && npm cache clean --force
COPY . .
RUN npm run build
CMD [ "npm", "start" ]