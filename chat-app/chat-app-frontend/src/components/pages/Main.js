import React, { useState, useEffect } from "react";
import axios from "axios";
import ChannelBar from "../ChannelBar";
import ChatWindow from "../ChatWindow";
import MessageBar from "../MessageBar";

const Main = () => {
  const [channels, setChannels] = useState([]); // for ChannelBar
  const [channelMessages, setChannelMessages] = useState([]); // For ChatWindow
  const [channelName, setChannelName] = useState("anime"); // for channelBar
  const [isNewMessage, setIsNewMessage] = useState(false);
  const [isNewChannel, setIsNewChannel] = useState(false);

  // grab all messages and channels
  useEffect(() => {
    getChannels();
    getChannelMessages();
  }, []);

  // grab all new messages if new message is sent
  useEffect(() => {
    if (isNewMessage) {
      getChannelMessages();
    }
  }, [isNewMessage]);

  // grab all channels is new channel is created
  useEffect(() => {
    if (isNewChannel) {
      getChannels();
    }
  }, [isNewChannel]);

  // grab all messages when switching to new channel
  useEffect(() => {
    getChannelMessages();
  }, [channelName]);

  const getChannels = async () => {
    const token = localStorage.getItem("token");
    if (token !== null) {
      const { data } = await axios
        .get("api/channel/channels", {
          headers: { Authorization: `Bearer ${token}` },
        })
        .catch((err) => console.log(err));
      setChannels(data);
    }
    // console.log("I rendered bc of setChannels 1");
  };

  // get all messages from current channel
  const getChannelMessages = async () => {
    const token = localStorage.getItem("token");
    if (token !== null) {
      const { data } = await axios
        .get(`api/channel/${channelName}/messages`, {
          headers: { Authorization: `Bearer ${token}` },
        })
        .catch((err) => console.log(err));
      setChannelMessages(data);
    }
  };

  return (
    <div>
      <div>
        <ChannelBar
          isNewChannel={isNewChannel}
          setIsNewChannel={setIsNewChannel}
          channels={channels}
          setChannels={setChannels}
          setChannelName={setChannelName}
        />
        {/* <DirectMessagesBar /> */}
      </div>

      <div>
        <ChatWindow
          channelName={channelName}
          channelMessages={channelMessages}
        />
      </div>
      <div>
        <MessageBar
          isNewMessage={isNewMessage}
          setIsNewMessage={setIsNewMessage}
          channelMessages={channelMessages}
          setChannelMessages={setChannelMessages}
          channelName={channelName}
        />
      </div>
    </div>
  );
};

export default Main;
